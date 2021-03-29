using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adutova_TKR2.Models
{
    public class DataBase
    {
        List<Employer> Employers { get; set; }
        List<Mission> Missions { get; set; }

        public static List<User> Users { get; } = new List<User>
        {
            new User(){ Login = "user", Password = "user" },
            new User(){ Login = "admin", Password = "admin" },
        };

        public DataBase()
        {
            Employers = new List<Employer>
            {
                new Employer("Vasya"),
                new Employer("Petya"),
                new Employer("AdutovaLiza"),
                new Employer("LebedevaAnna"),
            };
            Missions = new List<Mission>
            {
                new Mission("Task1"),
                new Mission("Task2"),
                new Mission("Project"),
                new Mission("Project55"),
            };
        }

        //Get the data about the class requested
        public List<Employer> GetEmployers()
        {
            return Employers;
        }
        public List<Mission> GetMissions()
        {
            return Missions;
        }

        public void AddEmployer(Employer employer)
        {
            Employers.Add(employer);
        }
        public void AddTask(Mission task)
        {
            Missions.Add(task);
        }

        public List<string> GetEmployersMissions(int EmployerId)
        {
            var Employer = Employers.FirstOrDefault(p => p.Id == EmployerId);
            if (Employer == null)
            {
                return null;
            }
            return Employer.TasksId.Select(id => GetTask(id)?.MissionTask ?? "").ToList();
        }
        public Mission GetTask(int EmployerId)
        {
            var task = Missions.FirstOrDefault(p => p.Id == EmployerId);
            return task;
        }

        public Employer GetEmployer(int EmployerId) => Employers.FirstOrDefault(p => p.Id == EmployerId);


        public bool AddTaskToEmployer(int EmployerId, int TaskId)
        {
            var Employer = GetEmployer(EmployerId); 
            var task = GetTask(TaskId);

            if (Employer == null || task == null)
                return false;

            task.SetEmployer(EmployerId);
            Employer.AddTask(TaskId);
            return true;
        }
    }
}

