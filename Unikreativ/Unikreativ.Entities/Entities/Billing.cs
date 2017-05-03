using System;
using System.Collections.Generic;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Billing
    {
        public double WorkingTime { get; set; }
        public double RateOfProject { get; set; }
        public double Total { get; set; }

        //nav prop
        public string MemberId { get; set; }

        public string ProjectId { get; set; }
        public string TaskId { get; set; }
    }
}