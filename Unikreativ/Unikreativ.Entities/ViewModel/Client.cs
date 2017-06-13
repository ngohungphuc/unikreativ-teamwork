﻿using System.ComponentModel.DataAnnotations;

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

        private readonly double ChargeRate = 0;

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}