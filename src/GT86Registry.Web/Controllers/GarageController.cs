using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GT86Registry.Web.Controllers
{
    [Authorize]
    public class GarageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVehicleViewModelService _vehicleViewModelService;
        private readonly VehicleRepository _vehicleRepository;

        public GarageController(VehicleRepository vehicleRepository, UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleViewModelService)
        {
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
            _vehicleViewModelService = vehicleViewModelService;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var vehicles = _vehicleViewModelService.GetTopVehicles().Where(x => x.OwnerUsername == user.UserName);

            return View(vehicles);
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            var vm = new AddVehicleViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddVehicle(AddVehicleViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditVehicle(string vin)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(vin);

            var vm = new EditVehicleViewModel
            {
                VehicleDescription = vehicle.Description
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditVehicle(EditVehicleViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteVehicle()
        {
            return View();
        }
    }
}