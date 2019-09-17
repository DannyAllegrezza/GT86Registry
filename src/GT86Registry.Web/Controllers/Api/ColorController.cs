using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [Route("api/colors")]
    [AllowAnonymous]
    public class ColorController : Controller
    {
        private readonly IAsyncRepository<Color> _repository;
        private readonly VehicleDbContext _vehicleContext;

        public ColorController(IAsyncRepository<Color> repository, VehicleDbContext vehicleContext)
        {
            _repository = repository;
            _vehicleContext = vehicleContext;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var allColors = await _repository.ListAllAsync();
            var projectedColors = allColors.Select(x => new
            {
                x.Name,
                x.Code,
                x.HexValue,
                x.CreatedDate,
                x.ModifiedDate
            });
                
            return Ok(projectedColors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllColorsAndRelatedYears()
        {

            return Ok();
        }
    }
}