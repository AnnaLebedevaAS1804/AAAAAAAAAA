using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adutova_TKR2.Models;


namespace Adutova_TKR2.Controllers
{
    [Route("api/Missions")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly TodoContext _context;

        public MissionController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Mission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissions()
        {
            return await _context.Missions.ToListAsync();
        }


        // GET: api/Missions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Mission>>> GetMission(int id)
        //{

        //    var mission =  await _context.Missions.FindAsync(id);
        //    if (mission == null)
        //    {
        //        return NotFound(new { errorText = $"Mission with id = {id} was not found." });
        //    }

        //    return new MissionLA(mission);
        //}
        public ActionResult<Mission> GetMission(int id)
        {
            var missions = Startup.database.GetMissions();
            var mission = missions.FirstOrDefault(i => i.Id == id);

            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        [HttpGet("{id}/employers")]
        public ActionResult<List<string>> GetEmployersMissions(int id) //by employers id
        {
            var mission = Startup.database.GetEmployersMissions(id); 

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        [HttpPost]
        public string AddTask([FromForm] Mission mission)
        {
            Startup.database.AddTask(mission);
            return "OK";
        }

        [HttpPost("{id}/employer={EmployerId}")]
        //public ActionResult<Mission> AddEmployer(int id, Employer employerid)
        //{
        //    var missions = Startup.database.GetMissions();
        //    var mission = missions.FirstOrDefault(i => i.Id == id);
        //    if (mission == null)
        //    {
        //        return NotFound();
        //    }
        //    var IsEmployerExists = mission.Employers.Contains(employerid);
        //    if (IsEmployerExists == false)
        //    {
        //        if (Startup.database.AddTaskToEmployer(id, employerid))
        //        {
        //            mission = missions.FirstOrDefault(i => i.Id == id);
        //            return Ok(mission);
        //        }
        //    }
        //    return Ok(mission);
        //}
        public ActionResult<Mission> AddEmployer(int id, int employerid)
        {
            var missions = Startup.database.GetMissions();
            var mission = missions.FirstOrDefault(i => i.Id == id);
            if (mission == null)
            {
                return NotFound();
            }
            var IsEmployerExists = mission.EmployersId.Contains(employerid);
            if (IsEmployerExists == false)
            {
                if (Startup.database.AddTaskToEmployer(id, employerid))
                {
                    mission = missions.FirstOrDefault(i => i.Id == id);
                    return Ok(mission);
                }
            }
            return Ok(mission);
        }

        // PUT: api/Missions/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(long id, Mission mission)
        {
            if (id != mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mission>> DeleteMission(long id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();

            return mission;
        }

        private bool MissionExists(long id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }
        //////////
        // GET: api/Missions/false
        [HttpGet("{IsComplete}")]
        public ActionResult<List<Mission>> GetReadinessMission(bool iscompl)
        {
            
            var missions = Startup.database.GetMissions();
            var mission = missions.Where(i => i.IsComplete == iscompl);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }
    }
}

