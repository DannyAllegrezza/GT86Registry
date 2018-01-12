using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Manufacturers { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
        public IEnumerable<SelectListItem> VehicleModels { get; set; }
        public IEnumerable<SelectListItem> ColorChoices { get; set; }


        public string VIN { get; set; }

        [BindRequired]
        [Display(Name = "Vehicle Year")]
        public int YearId { get; set; }

        [BindRequired]
        [Display(Name = "Vehicle Make")]
        public string ManufacturerName { get; set; }

        [BindRequired]
        [Display(Name = "Vehicle Model")]
        public string VehicleModelName { get; set; }

        [Display(Name = "Vehicle Color")]
        public string ColorName { get; set; }
    }
}
