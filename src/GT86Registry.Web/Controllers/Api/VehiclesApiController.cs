using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/vehicles")]
    public class VehiclesApiController : Controller
    {
        private readonly VehicleRepository _repository;
        private readonly IVinDecoderService _vinService;

        public VehiclesApiController(VehicleRepository repository, IVinDecoderService vinService)
        {
            _repository = repository;
            _vinService = vinService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = _repository.GetAllVehicles();

            return Ok(vehicles);
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
    }
}