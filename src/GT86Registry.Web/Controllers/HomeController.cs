using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GT86Registry.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVehicleViewModelService _vehicleService;

        public HomeController(UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleService)
        {
            _userManager = userManager;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetNewestRegisteredVehicles();

            return View("../Vehicles/VehiclesIndex", vehicles);
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
    }
}