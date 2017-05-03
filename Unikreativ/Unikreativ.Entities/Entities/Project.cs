using System;
using System.Collections.Generic;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime AgreementDate { get; set; }

        //nav properties
        public string ClientId { get; set; }
    }
}