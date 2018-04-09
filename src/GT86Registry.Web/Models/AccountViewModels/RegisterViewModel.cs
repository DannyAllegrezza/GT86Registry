using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public IEnumerable<SelectListItem> ColorChoices { get; set; }

        [Display(Name = "Vehicle Color")]
        public string ColorId { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [BindRequired]
        [Display(Name = "Vehicle Make")]
        public string ManufacturerId { get; set; }

        public IEnumerable<SelectListItem> Manufacturers { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> TransmissionChoices { get; set; }

        [Display(Name = "Vehicle Transmission")]
        public string TransmissionId { get; set; }

        [Display(Name = "Vehicle Image")]
        public Image VehicleImage { get; set; }

        public VehicleLocation VehicleLocation { get; set; }

        [BindRequired]
        [Display(Name = "Vehicle Model")]
        public string VehicleModelId { get; set; }

        public IEnumerable<SelectListItem> VehicleModels { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public string VIN { get; set; }

        [Display(Name = "Vehicle Year")]
        public int Year { get; set; }

        public int YearId { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}