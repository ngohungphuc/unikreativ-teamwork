﻿using System;
using System.Collections.Generic;
using Unikreativ.Entities.Entities;
namespace Unikreativ.Entities.ViewModel
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            Billings = new List<Billing>();
            Events = new List<Event>();
            SubTasks = new List<SubTask>();
        }
        private DateTime _AgreementDate = DateTime.Now;

        public Guid Id { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate
        {
            get { return _AgreementDate; } 
            set { _AgreementDate = value; }
        }

        public string UserName { get; set; }

        public User Client { get; set; }

        public IList<Billing> Billings { get; set; }
        public IList<Event> Events { get; set; }
        public IList<SubTask> SubTasks { get; set; }
    }
}
