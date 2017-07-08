using System;
using System.Collections.Generic;

namespace Unikreativ.Entities.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate { get; set; }

        public User Client { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }
    }
}