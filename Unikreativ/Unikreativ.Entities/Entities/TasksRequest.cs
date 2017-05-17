using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class TasksRequest : BaseEntity
    {
        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Due { get; set; }

        public double WorkingTime { get; set; }

        public double CompleteRate { get; set; }

        public bool IsCompleted { get; set; }

        public double CostOfTask { get; set; }

        public Billing Billing { get; set; }

        public Project Project { get; set; }

        public string AssignTo { get; set; }

        public string AssignBy { get; set; }

        public ICollection<MediaFile> MediaFiles { get; set; }
        public SubTask SubTask { get; set; }
    }
}