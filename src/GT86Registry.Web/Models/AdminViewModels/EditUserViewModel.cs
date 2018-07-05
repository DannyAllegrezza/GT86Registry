using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AdminViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the user name")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter the user email")]
        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
