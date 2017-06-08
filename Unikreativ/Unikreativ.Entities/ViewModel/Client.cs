using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.ViewModel
{
    public class Client
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string Website { get; set; }

        public int AccessFailedCount = 0;
        public double ChargeRate = 0;
        public bool EmailConfirmed = false;
        public bool LockoutEnabled = false;
        public bool PhoneNumberConfirmed = false;
        public bool TwoFactorEnabled = false;

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}