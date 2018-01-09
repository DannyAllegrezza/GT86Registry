using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<SelectListItem>> GetManufacturersByYear(int year);
        Task<IEnumerable<SelectListItem>> GetModels(int year, string manufacturer);
        Task<IEnumerable<SelectListItem>> GetAllYears();
    }
}
