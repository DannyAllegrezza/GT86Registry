using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Web.Models;
using GT86Registry.Web.Interfaces;
using Microsoft.AspNetCore.Identity;
using GT86Registry.Infrastructure.Identity;

namespace GT86Registry.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleViewModelService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, IVehicleViewModelService vehicleService)
        {
            _userManager = userManager;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetTopVehicles();
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
