using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Event : BaseEntity
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime DateAssigned { get; set; }

        public bool IsCompleted { get; set; }

        public string AssignBy { get; set; }

        public string AssignTo { get; set; }

        public TasksRequest TasksRequest { get; set; }

        public Project Project { get; set; }
    }
}