using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces.Services;
using GT86Registry.Web.Models.VehicleViewModels;
using System.Collections.Generic;

namespace GT86Registry.Web.Models.AccountViewModels
{
    public class UserProfileViewModel : IUserProfileViewModel
    {
        public ApplicationUser VehicleOwner { get; set; }
        public IEnumerable<VehicleOverviewViewModel> OwnerVehicles { get; set; }
    }
}
