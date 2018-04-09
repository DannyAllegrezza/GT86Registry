using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Interfaces.Services;
using GT86Registry.Web.Models.AccountViewModels;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT86Registry.Web.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VehicleRepository _vehicleRepository;

        public UserProfileService(UserManager<ApplicationUser> userManager, VehicleRepository vehicleRepository)
        {
            _userManager = userManager;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IUserProfileViewModel> GetProfileByUsername(string username)
        {
            var userProfileViewModel = new UserProfileViewModel();

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) { return userProfileViewModel; }

            var ownerVehicles = new List<VehicleOverviewViewModel>();
            var vehicles = _vehicleRepository.GetVehiclesByUserId(user.Id);

            foreach (var vehicle in vehicles)
            {
                ownerVehicles.Add(new VehicleOverviewViewModel()
                {
                    ImageUri = vehicle.Image.Uri,
                    Location = vehicle.VehicleLocation,
                    OwnerUsername = user.UserName,
                    Title = vehicle.ToString(),
                    ViewCount = vehicle.ViewCount,
                    VIN = vehicle.VIN
                });
            }

            userProfileViewModel.VehicleOwner = user;
            userProfileViewModel.OwnerVehicles = ownerVehicles;

            return userProfileViewModel;
        }
    }
}