using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GT86Registry.Web.Controllers.Api
{
    [Route("api/colors")]
    public class ColorController : Controller
    {
        private readonly IAsyncRepository<Color> _repository;

        public ColorController(IAsyncRepository<Color> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var allColors = await _repository.ListAllAsync();

            return Ok(allColors);
        }
    }
}