using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GT86Registry.Web.Controllers
{
    [Authorize]
    public class GarageController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public GarageController(VehicleRepository vehicleRepository, UserManager<ApplicationUser> userManager)
        {
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var vehicles = _vehicleRepository.GetVehiclesByUserId(user.Id);

            return View(vehicles);
        }
    }
}