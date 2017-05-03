using System;
using System.Collections.Generic;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class TasksRequest
    {
        public string TaskName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Due { get; set; }

        public double WorkingTime { get; set; }

        public double ComplteRate { get; set; }

        public bool IsCompleted { get; set; }

        public double CostOfTask { get; set; }

        //nav properties
        public string BillingId { get; set; }

        public string ProjectId { get; set; }

        public string MemberId { get; set; }

        public ICollection<MediaFile> MediaFiles { get; set; }
    }
}