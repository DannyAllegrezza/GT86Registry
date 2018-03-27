using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Models.VehicleViewModels;
using System.Collections.Generic;

namespace GT86Registry.Web.Interfaces.Services
{
    public interface IUserProfileViewModel
    {
        ApplicationUser VehicleOwner { get; set; }
        IEnumerable<VehicleOverviewViewModel> OwnerVehicles { get; set; }
    }
}
