using System;
using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.Models.AccountViewModels
{
    public class LoginViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}