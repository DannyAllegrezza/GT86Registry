using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/vehicles")]
    public class VehiclesApiController : Controller
    {
        private readonly VehicleRepository _repository;
        private readonly IVinDecoderService _vinService;
        private readonly IRepository<Vehicle> _vehicleRepo;
        private readonly VehicleDbContext _context;

        public VehiclesApiController(VehicleRepository repository, IVinDecoderService vinService, IRepository<Vehicle> vehicleRepo, VehicleDbContext context)
        {
            _repository = repository;
            _vinService = vinService;
            _vehicleRepo = vehicleRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = _repository.GetAllVehicles();
            var vinsOnly = _vehicleRepo.GetAllQueryable().Select(x => new
            {
                vin = x.VIN
            });

            return Ok(vinsOnly);
        }

        [HttpGet]
        [Route("{vin}")]
        public async Task<IActionResult> GetByVin(string vin)
        {
            if (vin == null) { return BadRequest(); }

            var decodedVin = await _vinService.GetDecodedVin(vin);

            if (decodedVin == null)
            {
                return BadRequest("Request was invalid");
            }

            return Ok(decodedVin);
        }

        [HttpPut]
        [Route("{vin}")]
        public async Task<IActionResult> UpdateVehicle(string vin)
        {
            //var vehicle1 = _vehicleRepo.GetAllQueryable().Where(x => x.VIN == vin).FirstOrDefault();
            //_vehicleRepo.Update(vehicle1);

            var vehicle = _context.Vehicles.Where(x => x.VIN == vin).First();
            vehicle.Description = "Totally updated!!!!!!!!!11111111";
            _context.Attach(vehicle);
            _context.SaveChanges();

            return Ok(vehicle);
        }
    }
}