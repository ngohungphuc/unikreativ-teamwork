using System;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.ViewModel
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            Project = new Project();
            TasksRequest = new TasksRequest();
        }
        
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime DateAssigned { get; set; }

        public bool IsCompleted { get; set; }

        public string AssignBy { get; set; }

        public string AssignTo { get; set; }

        public Project Project { get; set; }

        public TasksRequest TasksRequest { get; set; }

    }
}
