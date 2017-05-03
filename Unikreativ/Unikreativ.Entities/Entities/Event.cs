using System;
using System.Collections.Generic;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Event
    {
        public string TaskName { get; set; }

        public string Description { get; set; }

        public string AssignTo { get; set; }

        public DateTime DateAssigned { get; set; }

        public bool IsCompleted { get; set; }
    }
}