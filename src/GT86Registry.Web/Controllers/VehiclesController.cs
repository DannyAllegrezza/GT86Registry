using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Identity;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using Microsoft.AspNetCore.Routing;

namespace GT86Registry.Web.Controllers
{
   
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVehicleViewModelService _vehicleService;

        public VehiclesController(VehicleRepository repository, UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleService)
        {
            _vehicleRepository = repository;
            _userManager = userManager;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetVehicleOverviewViewModels();
            return View("VehiclesIndex", vehicles);
        }

        [Route("vehicles/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(id);
            var user = await _userManager.FindByIdAsync(vehicle.UserIdentityGuid);

            var vm = new VehicleDetailViewModel(){
                Vehicle = vehicle,
                VehicleOwner = user
            };

            vehicle.ViewCount++;
            _vehicleRepository.Update(vehicle);

            return View("_VehicleDetails", vm);
        }

        public async Task<IActionResult> GetProfile(string username)
        {
            //TODO(dca): create a user profile service to go fetch the user, lookup any potential vehicles, show profile page
            var user = await _userManager.FindByNameAsync(username);

            if (user == null) { return BadRequest("User not found!"); }

            var vehicles = _vehicleRepository.GetVehiclesByUserId(user.Id);
            return View("../Account/UserProfile", vehicles);
        }
    }
}