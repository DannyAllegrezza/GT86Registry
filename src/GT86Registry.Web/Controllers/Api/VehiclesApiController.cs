using GT86Registry.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [Route("api/vehicles")]
    public class VehiclesApiController : Controller
    {
        private readonly VehicleDbContext _context;
        private readonly VehicleRepository _repository;

        public VehiclesApiController(VehicleRepository repository, VehicleDbContext context)
        {
            _repository = repository;
            _context = context;
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

        [HttpGet]
        [Route("{graph}")]
        public IActionResult GetGraph()
        {
            var graph = _context.Years
                        .Include(y => y.Model)
                            .ThenInclude(yv => yv.Manufacturer)
                        .Include(y => y.ModelColors)
                        .Include(y => y.ModelTransmissions);

            return Ok(graph);
            // return a full graph of the data structure
        }
    }
}