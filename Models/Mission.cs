using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adutova_TKR2.Models
{
    public class Mission
    {
        //static int MaxId = 0;
        public int Id { get; private set; }
        public string MissionTask { get; private set; } //содержание
        public bool IsComplete { get; private set; } = false;
        // public List<Employer> Employers { get; private set; }
        public List<int> EmployersId { get; private set; }

        public Mission()
        { 
        }
        public void Done()
        {
            IsComplete = !IsComplete;
        }

        public void SetEmployer(Employer empl)
        {
            var employer = empl;
            //EmployersId;
        }

        public void ChangeTask(string mission)
        {
            MissionTask = mission;
        }

    }

    //public class MissionLA
    //{
    //    public int Id { get; private set; }
    //    public string MissionTask { get; private set; }
    //    public string IsComplete { get; private set; }
    //    public string EmployersId { get; private set; }

    //    public MissionLA(Mission mission)
    //    {
    //        //MaxId++;
    //        //Id = MaxId;
    //        Id = mission.Id;
    //        MissionTask = mission.MissionTask;
    //        if (mission.IsComplete)
    //            IsComplete = "Already done";
    //        else
    //            IsComplete = "Not yet";
    //        EmployersId = new string("");
    //        if (mission.Employers != null)
    //        {
    //            foreach (Employer em in mission.Employers)
    //                EmployersId += $"{em.Id}{em.Name}";
    //            EmployersId = EmployersId.Substring(0, EmployersId.Length - 2);
    //        }
    //    }
    //}
       
}
