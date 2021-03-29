using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adutova_TKR2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adutova_TKR2.Controllers
{
    [Route("api/Employers")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly TodoContext _context;

        public EmployerController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Employers
        [HttpGet]
        public IEnumerable<Employer> GetEmployers()
        {
            return Startup.database.GetEmployers();
        }


        // GET: api/Employers/5

        [HttpGet("{id}")]
        public ActionResult<Employer> GetEmployer(int id) 
        {
            var employers = Startup.database.GetEmployers();
            var employer = employers.FirstOrDefault(i => i.Id == id);

            if (employer == null)
            {
                return NotFound();
            }

            return Ok(employer);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(long id, Employer employer)
        {
            if (id != employer.Id)
            {
                return BadRequest();
            }

            _context.Entry(employer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers
        [HttpPost]
        public async Task<ActionResult<Employer>> PostEmployer(Employer employer)
        {
            _context.Employers.Add(employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployer", new { id = employer.Id }, employer);
        }

        // DELETE: api/Employers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employer>> DeleteEmployer(long id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return employer;
        }

        private bool EmployerExists(long id)
        {
            return _context.Employers.Any(e => e.Id == id);
        }
        ////////////////////////
        
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employer>> GetEmployersMissions(long id)
        //{
        //    var employer = await _context.Employers.FindAsync(id);
        //    if (employer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employers.Remove(employer);
        //    await _context.SaveChangesAsync();

        //    return employer;
        //}

    }
}
