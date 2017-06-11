using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unikreativ.Entities.Entities
{
    public class Billing : BaseEntity
    {
        public double WorkingTime { get; set; }

        public double RateOfTask { get; set; }

        public double Total { get; set; }

        [ForeignKey("TasksRequest")]
        public Guid TasksRequestId { get; set; }

        public TasksRequest TasksRequest { get; set; }

        public Project Project { get; set; }
    }
}