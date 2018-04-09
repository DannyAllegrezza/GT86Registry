using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for a service which can be used to create VehicleViewModels
    /// </summary>
    public interface IVehicleViewModelService
    {
        IEnumerable<SelectListItem> GetAllYears();

        IEnumerable<SelectListItem> GetAvailableColorsForModel(int year, int modelId);

        IEnumerable<SelectListItem> GetManufacturersByYear(int year);

        IEnumerable<SelectListItem> GetModels(int year, int manufacturerId);

        IEnumerable<SelectListItem> GetTransmissionChoicesForModel(int year, int modelId);

        IEnumerable<VehicleOverviewViewModel> GetVehicleOverviewViewModels();

        Task<VehicleOverviewViewModel> GetVehicleOverviewViewModels(int pageIndex, int itemsPage, int? brandId, int? typeId);
    }
}