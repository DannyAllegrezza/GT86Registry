using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public IEnumerable<SelectListItem> ColorChoices { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string ColorId { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Manufacturer")]
        public string ManufacturerId { get; set; }

        public IEnumerable<SelectListItem> Manufacturers { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public IEnumerable<SelectListItem> TransmissionChoices { get; set; }

        [Display(Name = "Transmission")]
        [Required]
        public string TransmissionId { get; set; }

        [Display(Name = "Profile Photo")]
        public Image VehicleImage { get; set; }

        [Display(Name = "Location")]
        public VehicleLocation VehicleLocation { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string VehicleModelId { get; set; }

        public IEnumerable<SelectListItem> VehicleModels { get; set; }

        public VehicleStatus VehicleStatus { get; set; }

        [Required]
        public string VIN { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int YearId { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}