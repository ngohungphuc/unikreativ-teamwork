using System;
using Unikreativ.Entities.Entities;
namespace Unikreativ.Entities.ViewModel
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate = DateTime.Now;

        public string UserName { get; set; }

        public User Client { get; set; }
    }
}
