using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VehicleRepository _repository;

        public VehiclesController(VehicleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = _repository.GetAllVehicles();

            return Ok(vehicles);
        }

        [HttpGet]
        [Route("{vin}")]
        public IActionResult GetByVin(string vin)
        {
            if (vin == null) { return BadRequest(); }

            var vehicle = _repository.GetVehicleByVIN(vin);
            return Ok(vehicle);
        }
    }
}
