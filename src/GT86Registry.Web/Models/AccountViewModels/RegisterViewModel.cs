using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(17)]
        [Display(Name = "Vehicle Information Number (VIN)")]
        public string VIN { get; set; }

        
        [Display(Name = "Transmission")]
        public string TransmissionId { get; set; }

        [Display(Name = "Color")]
        public string ColorId { get; set; }

        [Display(Name = "Manufacturer")]
        public string ManufacturerId { get; set; }

        [Display(Name = "Model")]
        public string VehicleModelId { get; set; }

        [Display(Name = "Year")]
        public int YearId { get; set; }
        public int Year { get; set; }

        public Image VehicleImage { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
        public VehicleLocation VehicleLocation { get; set; }

        public IEnumerable<SelectListItem> ColorChoices { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
        public IEnumerable<SelectListItem> TransmissionChoices { get; set; }
        public IEnumerable<SelectListItem> VehicleModels { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}