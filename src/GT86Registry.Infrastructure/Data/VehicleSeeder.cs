using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GT86Registry.Core.Entities;
using System.Threading.Tasks;

namespace GT86Registry.Infrastructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleSeeder
    {
        private readonly VehicleDbContext _vehicleContext;

        public VehicleSeeder(VehicleDbContext ctx)
        {
            _vehicleContext = ctx;
        }

        public async Task SeedAsync()
        {
            // Create Manufacturers
            if (!_vehicleContext.Manufacturers.Any())
            {
                _vehicleContext.Manufacturers.AddRange(GetDefaultManufacturers());

                await _vehicleContext.SaveChangesAsync();
            }

            // Create vehicle Models
            if (!_vehicleContext.VehicleModels.Any())
            {
                _vehicleContext.VehicleModels.AddRange(GetDefaultVehicleModels());

                await _vehicleContext.SaveChangesAsync();
            }

            if (!_vehicleContext.Years.Any())
            {
                _vehicleContext.Years.AddRange(GetDefaultModelYears());

                await _vehicleContext.SaveChangesAsync();
            }

        }

        private IEnumerable<Manufacturer> GetDefaultManufacturers()
        {
            var subaruStartDate = new DateTime(1953, 7, 15);
            var scionStartDate = new DateTime(2003, 6, 9);
            var scionEndDate = new DateTime(2016, 8, 5);
            var toyotaStartDate = new DateTime(1937, 8, 28);
            var nissanStartDate = new DateTime(1933, 12, 26);


            return new List<Manufacturer>()
            {
                new Manufacturer("Subaru", subaruStartDate, null),
                new Manufacturer("Scion", scionEndDate, scionEndDate),
                new Manufacturer("Toyota", toyotaStartDate, null),
                new Manufacturer("Nissan", nissanStartDate, null)
            };
        }

        private IEnumerable<Model> GetDefaultVehicleModels()
        {
            return new List<Model>()
            {
                new Model("BRZ", 1),
                new Model("FR-S", 2),
                new Model("GT86", 3),
                new Model("240SX", 4)
            };
        }

        private IEnumerable<ModelYear> GetDefaultModelYears()
        {
            var modelYears = new List<ModelYear>();

            // Subaru BRZ and Toyota GT86
            for (int year = 2013; year <= 2018; year++)
            {
                var brz = new ModelYear(year, 1);
                var gt86 = new ModelYear(year, 3);
                modelYears.Add(brz);
                modelYears.Add(gt86);
            }

            // Scion FR-S
            for (int year = 2013; year <= 2017; year++)
            {
                var frs = new ModelYear(year, 2);
                modelYears.Add(frs);
            }           

            return modelYears;
        }
    }
}
