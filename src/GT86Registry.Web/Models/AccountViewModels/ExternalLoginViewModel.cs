using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}