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

        public DateTime AgreementDate { get; set; }

        public User User { get; set; }
    }
}
