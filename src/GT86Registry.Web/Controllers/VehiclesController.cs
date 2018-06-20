using GT86Registry.Infrastructure.Data;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Helpers;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers
{
    [AllowAnonymous]
    public class VehiclesController : Controller
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileService _userProfileService;
        private readonly VehicleRepository _vehicleRepository;
        private readonly IVehicleViewModelService _vehicleService;

        public VehiclesController(
            VehicleRepository repository,
            UserManager<ApplicationUser> userManager,
            IVehicleViewModelService vehicleService,
            IUserProfileService userProfileService,
            ILogger<VehiclesController> logger
            )
        {
            _vehicleRepository = repository;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _userProfileService = userProfileService;
            _logger = logger;
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
            var vehicles = _vehicleService.GetNewestRegisteredVehicles();

            return View("VehiclesIndex", vehicles);
        }

        /// <summary>
        /// Fetches all registered users and their associated locations to render on a map. Filtering takes place on client-side
        /// </summary>
        /// <returns></returns>
        [Route("map")]
        public async Task<IActionResult> Map()
        {
            return View();
        }

        /// <summary>
        /// Displays the core Registry, which contains all vehicles. The client side is responsible for filtering and rendering data.
        /// </summary>
        /// <returns></returns>
        [Route("registry")]
        public async Task<IActionResult> Registry()
        {
            var vehicles = _vehicleService.GetVehicleOverviewViewModels();
            
            return View("Registry", vehicles);
        }

        public async Task<IActionResult> Profile(string username)
        {
            
            var profile = await _userProfileService.GetProfileByUsername(username);
            if (profile.VehicleOwner == null)
            {
                return new PageNotFound();
            }

            return View("~/Views/Account/UserProfile.cshtml", profile);
        }
    }
}