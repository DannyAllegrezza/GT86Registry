using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GT86Registry.Web.Services
{
    public class VehicleViewModelService : IVehicleViewModelService
    {
        private readonly IRepository<ColorsModelYears> _colorsRepository;
        private readonly VehicleDbContext _vehicleContext;
        private readonly IRepository<ModelYear> _yearRepository;

        public VehicleViewModelService(
                IRepository<ModelYear> yearRepository,
                IRepository<ColorsModelYears> colorRepository,
                VehicleDbContext vehicleContext)
        {
            _yearRepository = yearRepository;
            _colorsRepository = colorRepository;
            _vehicleContext = vehicleContext;
        }

        public async void CreateVehicleForUser(string userId, RegisterViewModel viewModel)
        {
        }

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
                items.Add(new SelectListItem() { Value = year.Year.ToString(), Text = year.Year.ToString() });
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetAvailableColorsForModel(int year, string model)
        {
            var colorChoices = _colorsRepository.GetAllQueryable()
                            .Include(c => c.Color)
                            .Include(c => c.ModelYear.Model)
                            .Where(c => c.ModelYear.Year == year
                                    && c.ModelYear.Model.Name == model);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Color", Selected = true }
            };

            foreach (var color in colorChoices)
            {
                items.Add(new SelectListItem() { Value = color.Color.Name, Text = $"{color.Color.Name} ({color.Color.Code})" });
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
                items.Add(new SelectListItem() { Value = manufacturer.Name, Text = manufacturer.Name });
            }

            return items;
        }

        public IEnumerable<SelectListItem> GetModels(int year, string manufacturer)
        {
            var car = _yearRepository.GetAllQueryable()
                        .Include(vm => vm.Model)
                        .Include(vm => vm.Model.Manufacturer);

            var filteredCar = car.Where(m => m.Model.Manufacturer.Name == manufacturer && m.Year == year).FirstOrDefault();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Model", Selected = true },
                new SelectListItem() { Value = filteredCar.Model.Name, Text = filteredCar.Model.Name}
            };

            return items;
        }
    }
}