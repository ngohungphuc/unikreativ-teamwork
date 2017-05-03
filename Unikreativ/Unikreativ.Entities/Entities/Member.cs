using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class Member : BaseUser
    {
        public string Name { get; set; }

        public string JobTitle { get; set; }

        public double ChargeRate { get; set; }

        public string Status { get; set; }

        //add nav
    }
}