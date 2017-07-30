using System;
using System.Collections.Generic;
using System.Text;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.ViewModel
{
    public class ProjectViewModel
    {
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate = DateTime.Now;

        public string UserName { get; set; }

        public ICollection<Billing> Billings = new List<Billing>();
        public ICollection<Event> Events = new List<Event>();
        public ICollection<SubTask> SubTasks = new List<SubTask>();
    }
}
