using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Identity;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.VehicleViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Services
{
    public class VehicleViewModelService : IVehicleViewModelService
    {
        #region Properties

        private readonly IRepository<ColorsModelYears> _colorsRepository;
        private readonly IRepository<ModelTransmissions> _transmissionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<ModelYear> _yearRepository;

        #endregion Properties

        #region Constructors

        public VehicleViewModelService(
                IRepository<ModelYear> yearRepository,
                IRepository<ColorsModelYears> colorRepository,
                IRepository<ModelTransmissions> transmissionRepository,
                IRepository<Vehicle> vehicleRepository,
                UserManager<ApplicationUser> userManager
            )
        {
            _yearRepository = yearRepository;
            _colorsRepository = colorRepository;
            _transmissionRepository = transmissionRepository;
            _vehicleRepository = vehicleRepository;
            _userManager = userManager;
        }

        #endregion Constructors

        public IEnumerable<SelectListItem> GetAllYears()
        {
            var allYears = _yearRepository.GetAll();

            var allDistinctYears = allYears
                                .GroupBy(my => my.Year)
                                .Select(my => my.First())
                                .ToList();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Year", Selected = true }
            };

            foreach (var year in allDistinctYears)
            {
                items.Add(new SelectListItem() { Value = year.Id.ToString(), Text = year.Year.ToString() });
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetAvailableColorsForModel(int year, int modelId)
        {
            var colorChoices = _colorsRepository.GetAllQueryable()
                            .Include(c => c.Color)
                            .Include(c => c.ModelYear.Model)
                            .Where(c => c.ModelYear.Year == year
                                    && c.ModelYear.Model.Id == modelId);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Color", Selected = true }
            };

            foreach (var color in colorChoices)
            {
                items.Add(new SelectListItem() { Value = color.Color.Id.ToString(), Text = $"{color.Color.Name} ({color.Color.Code})" });
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetManufacturersByYear(int year)
        {
            var manufacturers = _yearRepository.GetAllQueryable()
                                .Where(my => my.Year == year)
                                .Select(my => my.Model.Manufacturer)
                                .ToList();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Make", Selected = true }
            };

            foreach (var manufacturer in manufacturers)
            {
                items.Add(new SelectListItem() { Value = manufacturer.Id.ToString(), Text = manufacturer.Name });
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetModels(int year, int manufacturerId)
        {
            var car = _yearRepository.GetAllQueryable()
                        .Include(vm => vm.Model)
                        .Include(vm => vm.Model.Manufacturer);

            var filteredCar = car.Where(m => m.Model.Manufacturer.Id == manufacturerId && m.Year == year).FirstOrDefault();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Model", Selected = true },
                new SelectListItem() { Value = filteredCar.Model.Id.ToString(), Text = filteredCar.Model.Name}
            };

            return items;
        }

        public IEnumerable<VehicleOverviewViewModel> GetVehicleOverviewViewModels()
        {
            List<VehicleOverviewViewModel> vehicleViewModels = new List<VehicleOverviewViewModel>();

            var vehicles = _vehicleRepository.GetAllQueryable()
                        .Include(vehicle => vehicle.ModelYear)
                                            .ThenInclude(v => v.Model)
                                            .ThenInclude(v => v.Manufacturer)
                                        .Include(vehicle => vehicle.Color)
                                        .Include(vehicle => vehicle.Transmission)
                                        .Include(vehicle => vehicle.Image)
                                        .Include(vehicle => vehicle.VehicleLocation)
                                        .Include(vehicle => vehicle.Status);

            foreach (var vehicle in vehicles)
            {
                var user = _userManager.FindByIdAsync(vehicle.UserIdentityGuid).Result;
                var vm = new VehicleOverviewViewModel()
                {
                    ImageUri = vehicle.Image.Uri,
                    Location = vehicle.VehicleLocation,
                    OwnerUsername = user.UserName,
                    Title = vehicle.ToString(),
                    ViewCount = vehicle.ViewCount,
                    VIN = vehicle.VIN
                };

                vehicleViewModels.Add(vm);
            }

            return vehicleViewModels;
        }

        public Task<VehicleOverviewViewModel> GetVehicleOverviewViewModels(int pageIndex, int itemsPage, int? brandId, int? typeId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SelectListItem> GetTransmissionChoicesForModel(int year, int modelId)
        {
            var transmissions = _transmissionRepository.GetAllQueryable()
                                        .Where(t => t.ModelYear.Year == year && t.ModelYear.Model.Id == modelId)
                                        .Include(t => t.Transmission)
                                        .Include(t => t.ModelYear);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Transmission", Selected = true }
            };

            foreach (var transmission in transmissions)
            {
                items.Add(new SelectListItem() { Value = transmission.Transmission.Id.ToString(), Text = transmission.Transmission.Name });
            }

            return items;
        }
    }
}