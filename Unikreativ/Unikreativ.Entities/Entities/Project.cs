using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Project : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate { get; set; }

        public string ClientId { get; set; }

        public string BillingId { get; set; }

        public string EventId { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<SubTask> SubTasks { get; set; }
    }
}