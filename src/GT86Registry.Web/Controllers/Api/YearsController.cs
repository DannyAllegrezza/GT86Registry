using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GT86Registry.Web.Interfaces;

namespace GT86Registry.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Years")]
    public class YearsController : Controller
    {
        private readonly IVehicleViewModelService _vehicleService;

        public YearsController(IVehicleViewModelService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Gets all the available distinct vehicle Years
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return null;
        }
    }
}