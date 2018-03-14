using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Web.Models;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Interfaces;

namespace GT86Registry.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVehicleViewModelService _vehicleService;

        public HomeController(IVehicleViewModelService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetTopVehicles();
            return View("../Vehicles/VehiclesIndex", vehicles);
        }


        public IActionResult User(string username)
        {
            return null;
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
