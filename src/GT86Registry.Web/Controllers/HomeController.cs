using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace GT86Registry.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IVehicleViewModelService _vehicleService;

        public HomeController(UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleService, IConfiguration configuration)
        {
            _userManager = userManager;
            _vehicleService = vehicleService;
            _configuration = configuration;
        }

        [Route("/about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetNewestRegisteredVehicles();


            ViewData["VehiclePlatform"] = _configuration["SiteSettings:VehiclePlatform"];
            ViewData["Manufacturers"] = _configuration["SiteSettings:Manufacturers"];
            return View("../Vehicles/VehiclesIndex", vehicles);
        }
    }
}