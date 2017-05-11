using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public DateTime AgreementDate { get; set; }

        public ApplicationUser ClientId { get; set; }

        public ICollection<Billing> Billings { get; set; }

        public ICollection<ApplicationUser> Members { get; set; }
    }
}