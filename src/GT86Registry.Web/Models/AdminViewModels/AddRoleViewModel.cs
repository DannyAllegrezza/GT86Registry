using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AdminViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
