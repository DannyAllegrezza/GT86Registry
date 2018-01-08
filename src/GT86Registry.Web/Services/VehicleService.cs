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

namespace GT86Registry.Web.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext _vehicleContext;
        private readonly IAsyncRepository<ModelYear> _yearRepository;

        public VehicleService(VehicleDbContext vehicleContext, IAsyncRepository<ModelYear> yearRepository)
        {
            _vehicleContext = vehicleContext;
            _yearRepository = yearRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllYears()
        {
            var allYears = await _yearRepository.ListAllAsync();

            var allDistinctYears = _vehicleContext.Years
                        .GroupBy(my => my.Year)
                        .Select(my => my.First())
                        .ToList();


            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "Select your manufacturer", Selected = true }
            };

            foreach (var year in allDistinctYears)
            {
                items.Add(new SelectListItem() { Value = year.Id.ToString(), Text = year.Year.ToString() });   
            }

            return items;
        }

        public Task<IEnumerable<SelectListItem>> GetManufacturersByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SelectListItem>> GetModels(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }
    }
}
