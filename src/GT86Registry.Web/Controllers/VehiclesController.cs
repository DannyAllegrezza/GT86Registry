using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Infrastructure.Data;

namespace GT86Registry.Web.Controllers
{
   
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehiclesController(VehicleRepository repository)
        {
            _vehicleRepository = repository;
        }

        public IActionResult Index()
        {
            return View("VehiclesIndex",_vehicleRepository.GetAllVehicles());
        }

        public IActionResult Details(string id)
        {
            var vehicle = _vehicleRepository.GetVehicleByVIN(id);

            vehicle.ViewCount++;
            _vehicleRepository.Update(vehicle);

            return View("_VehicleDetails", vehicle);
        }

    }
}