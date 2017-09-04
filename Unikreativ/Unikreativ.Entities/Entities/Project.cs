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
        public IList<Billing> Billings { get; set; }
        public IList<Event> Events { get; set; }
        public IList<TasksRequest> TasksRequests { get; set; }
        public IList<SubTask> SubTasks { get; set; }
    }
}