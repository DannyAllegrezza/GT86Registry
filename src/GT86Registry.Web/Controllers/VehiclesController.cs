using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileService _userProfileService;
        private readonly VehicleRepository _vehicleRepository;
        private readonly IVehicleViewModelService _vehicleService;

        public VehiclesController(
            VehicleRepository repository,
            UserManager<ApplicationUser> userManager,
            IVehicleViewModelService vehicleService,
            IUserProfileService userProfileService
            )
        {
            _vehicleRepository = repository;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _userProfileService = userProfileService;
        }

        [Route("vehicles/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(id);
            var user = await _userManager.FindByIdAsync(vehicle.UserIdentityGuid);

            var vm = new VehicleDetailViewModel()
            {
                Vehicle = vehicle,
                VehicleOwner = user
            };

            vehicle.ViewCount++;
            _vehicleRepository.Update(vehicle);

            return View("_VehicleDetails", vm);
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetVehicleOverviewViewModels();

            return View("VehiclesIndex", vehicles);
        }

        [Route("map")]
        public async Task<IActionResult> Map()
        {
            return View();
        }

        public async Task<IActionResult> Profile(string username)
        {
            var profile = await _userProfileService.GetProfileByUsername(username);

            return View("../Account/UserProfile", profile);
        }
    }
}