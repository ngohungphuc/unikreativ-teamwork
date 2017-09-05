using System;
using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.ViewModel
{
    public class Client
    {
        public string Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string Website { get; set; }

        public string UserName { get; set; }

        private double _ChargeRate = 0;
        public double ChargeRate
        {
            get { return _ChargeRate; }
            set { _ChargeRate = value; }
        }

        private bool _EmailConfirmed = false;
        public bool EmailConfirmed
        {
            get { return _EmailConfirmed; }
            set { _EmailConfirmed = value; }
        }

        private bool _LockoutEnabled = false;
        public bool LockoutEnabled
        {
            get { return _LockoutEnabled; }
            set { _LockoutEnabled = value; }
        }
    }
}