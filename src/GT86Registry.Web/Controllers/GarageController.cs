using GT86Registry.Infrastructure.Auth;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Helpers;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers
{
    public class GarageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VehicleRepository _vehicleRepository;
        private readonly IVehicleViewModelService _vehicleViewModelService;
        private readonly IAuthorizationService _authService;

        public GarageController(
            VehicleRepository vehicleRepository,
            UserManager<ApplicationUser> userManager,
            IVehicleViewModelService vehicleViewModelService,
            IAuthorizationService authService)
        {
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
            _vehicleViewModelService = vehicleViewModelService;
            _authService = authService;
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
        public IActionResult DeleteVehicle()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditVehicle(string vin)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(vin);
            if (vehicle == null)
            {
                return new PageNotFound();
            }

            var isAuthorized = await _authService.AuthorizeAsync(User, vehicle, VehicleOwnerOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            var vm = new EditVehicleViewModel
            {
                Vehicle = vehicle
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EditVehicle(EditVehicleViewModel viewModel)
        {
            _vehicleRepository.Update(viewModel.Vehicle);
            return View();
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var vehicles = _vehicleViewModelService.GetVehicleOverviewViewModels().Where(x => x.OwnerUsername == user.UserName);

            return View(vehicles);
        }
    }
}