using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adutova_TKR2.Models
{
    public class Employer
    {
        static int MaxId = 0;
        [BindRequired] public int Id { get; private set; }
        [BindRequired] public string Name { get; private set; }
        public List<int> TasksId { get; private set; }
        public Employer(string name)  
        {
            MaxId++;   ////////
            Id=MaxId;
            Name = name;
            TasksId = new List<int>();
        }

        public void AddTask(int id)
        {
            TasksId.Add(id); 
        }
    }
}
