using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Core.Interfaces;
using GT86Registry.Core.Entities;

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

            foreach (var color in allColors)
            {
                
            }

            return Ok(allColors);
        }
    }
}