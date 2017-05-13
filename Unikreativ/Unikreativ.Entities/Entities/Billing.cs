﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}