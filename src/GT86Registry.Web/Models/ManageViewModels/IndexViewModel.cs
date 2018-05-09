using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
        public string Username { get; set; }

        [Display(Name = "About me")]
        public string ProfileDescription { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Facebook Profile Address")]
        public string FacebookUri { get; set; }

        [Display(Name = "Instagram Username")]
        public string InstagramUri { get; set; }
    }
}