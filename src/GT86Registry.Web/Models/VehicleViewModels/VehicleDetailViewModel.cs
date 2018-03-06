using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;

namespace GT86Registry.Web.Models.VehicleViewModels
{
    public class VehicleDetailViewModel : IVehicleViewModel
    {
        public ApplicationUser VehicleOwner { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}