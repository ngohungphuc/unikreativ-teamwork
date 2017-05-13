using System.ComponentModel.DataAnnotations;

namespace Unikreativ.Entities.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
