using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for a service which can be used to create VehicleViewModels
    /// </summary>
    public interface IVehicleViewModelService
    {
        IEnumerable<SelectListItem> GetManufacturersByYear(int year);
        IEnumerable<SelectListItem> GetModels(int year, string manufacturer);
        IEnumerable<SelectListItem> GetAllYears();
        IEnumerable<SelectListItem> GetAvailableColorsForModel(int year, string model);
    }
}
