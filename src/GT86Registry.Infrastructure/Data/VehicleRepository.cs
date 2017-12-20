using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Infrastructure.Data
{
    public class VehicleRepository : EFRepository<Vehicle>
    {
        public VehicleRepository(VehicleDbContext vehicleContext) : base(vehicleContext)
        {
        }

        /// <summary>
        /// Gets all the Vehicles in the database, along with their related entities.
        /// </summary>
        /// <returns>A collection of Vehicle objects, along with their related entities.</returns>
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var vehicles = _vehicleContext.Vehicles
                                .Include(vehicle => vehicle.ModelYear)
                                    .ThenInclude(v => v.Model)
                                    .ThenInclude(v => v.Manufacturer)
                                .Include(vehicle => vehicle.Color)
                                .Include(vehicle => vehicle.Transmission)
                                .Include(vehicle => vehicle.Image)
                                .Include(vehicle => vehicle.VehicleLocation);

            return vehicles;
 
        }

        public Vehicle GetVehicleById(string vin)
        {
            var vehicle = _vehicleContext.Vehicles.Find(vin);
            return vehicle;
        }
    }
}
