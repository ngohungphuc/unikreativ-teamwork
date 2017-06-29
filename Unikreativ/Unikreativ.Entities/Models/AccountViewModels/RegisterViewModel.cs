using System.ComponentModel.DataAnnotations;
using Unikreativ.Entities.Entities;

namespace Unikreativ.Entities.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public User User { get; set; }
        public string Code { get; set; }
        public string CallbackUrl { get; set; }
    }
}