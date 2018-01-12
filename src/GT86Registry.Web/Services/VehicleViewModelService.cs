using GT86Registry.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GT86Registry.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using GT86Registry.Infrastructure.Data;
using GT86Registry.Web.Models.AccountViewModels;
using GT86Registry.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GT86Registry.Web.Services
{
    public class VehicleViewModelService : IVehicleViewModelService
    {
        private readonly IAsyncRepository<ModelYear> _yearRepository;
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;
        private readonly IAsyncRepository<Model> _vehicleModelRepository;
        private readonly VehicleDbContext _vehicleContext;

        public VehicleViewModelService(IAsyncRepository<ModelYear> yearRepository, 
                    IAsyncRepository<Manufacturer> manufacturerRepository,
                    IAsyncRepository<Model> vehicleModelRepository,
                    VehicleDbContext vehicleContext)
        {
            _yearRepository = yearRepository;
            _manufacturerRepository = manufacturerRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleContext = vehicleContext;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllYears()
        {
            var allYears = await _yearRepository.ListAllAsync();

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

        public async Task<IEnumerable<SelectListItem>> GetManufacturersByYear(int year)
        {

            var manufacturers = _vehicleContext.Years
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

        public async Task<IEnumerable<SelectListItem>> GetModels(int year, string manufacturer)
        {

            var car = _vehicleContext.Years
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

        public async void CreateVehicleForUser(string userId, RegisterViewModel viewModel)
        {

        }
        
        public async Task<IEnumerable<SelectListItem>> GetAvailableColorsForModel(int year,  string model)
        {
            // TODO (dca): query the join table instead
            var colorChoices = _vehicleContext.ColorYears
                                .Include(cy => cy.Color)
                                .Include(cy => cy.ModelYear.Model)
                                .Where(c => c.ModelYear.Year == year 
                                    && c.ModelYear.Model.Name == model);

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select Make", Selected = true }
            };

            foreach (var color in colorChoices)
            {
                items.Add(new SelectListItem() { Value = color.Color.Name, Text = $"{color.Color.Name} ({color.Color.Code})" });
            }

            return items;
        }
    }
}
