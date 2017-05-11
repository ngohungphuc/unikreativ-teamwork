using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Billing : BaseEntity
    {
        public double WorkingTime { get; set; }

        public double RateOfTask { get; set; }

        public double Total { get; set; }

        public ApplicationUser MemberRecevied { get; set; }

        public Project Project { get; set; }

        public TasksRequest TaskRequest { get; set; }
    }
}