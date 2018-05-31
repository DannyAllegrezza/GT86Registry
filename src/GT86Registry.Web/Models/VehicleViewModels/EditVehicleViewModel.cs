using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;

namespace GT86Registry.Web.Models.VehicleViewModels
{
    public class EditVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public ApplicationUser VehicleOwner { get; set; }
    }
}