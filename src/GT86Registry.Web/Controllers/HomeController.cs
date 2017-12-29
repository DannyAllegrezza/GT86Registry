using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Web.Models;
using GT86Registry.Infrastructure.Data;

namespace GT86Registry.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;

        public HomeController(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IActionResult Index()
        {
            return View(_vehicleRepository.GetAllVehicles());
        }

        [Route("{username}")]
        public IActionResult UserProfile(string username)
        {
            return null;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

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
