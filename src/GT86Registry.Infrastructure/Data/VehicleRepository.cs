using GT86Registry.Core.DTOs;
using GT86Registry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
                                .Include(vehicle => vehicle.VehicleLocation)
                                .Include(vehicle => vehicle.Status);

            return vehicles;
        }

        /// <summary>
        /// Gets all the Vehicles in the database, along with their related entities.
        /// </summary>
        /// <returns>A collection of Vehicle objects, along with their related entities.</returns>
        public IEnumerable<VehicleDto> GetAllVehiclesDto()
        {
            var vehicles = _vehicleContext.Vehicles
                                .Include(vehicle => vehicle.ModelYear)
                                    .ThenInclude(v => v.Model)
                                    .ThenInclude(v => v.Manufacturer)
                                .Include(vehicle => vehicle.Color)
                                .Include(vehicle => vehicle.Transmission)
                                .Include(vehicle => vehicle.Image)
                                .Include(vehicle => vehicle.VehicleLocation)
                                .Include(vehicle => vehicle.Status);

            var vehicleDtos = new List<VehicleDto>();

            foreach (var vehicle in vehicles)
            {
                vehicleDtos.Add(new VehicleDto(vehicle));
            }

            return vehicleDtos;
        }

        /// <summary>
        /// Gets a single Vehicle, by VIN, along with with related entities.
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public Vehicle GetVehicleByVIN(string vin)
        {
            var singleVehicle = _vehicleContext.Vehicles.Where(vehicle => vehicle.VIN == vin)
                                .Include(vehicle => vehicle.ModelYear)
                                    .ThenInclude(v => v.Model)
                                    .ThenInclude(v => v.Manufacturer)
                                .Include(vehicle => vehicle.Color)
                                .Include(vehicle => vehicle.Transmission)
                                .Include(vehicle => vehicle.Image)
                                .Include(vehicle => vehicle.VehicleLocation)
                                .Include(vehicle => vehicle.Status)
                                .First();

            return singleVehicle;
        }

        /// <summary>
        /// Gets a single Vehicle, by VIN, along with with related entities.
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        public VehicleDto GetVehicleByVINDto(string vin)
        {
            var singleVehicle = _vehicleContext.Vehicles.Where(vehicle => vehicle.VIN == vin)
                                .Include(vehicle => vehicle.ModelYear)
                                    .ThenInclude(v => v.Model)
                                    .ThenInclude(v => v.Manufacturer)
                                .Include(vehicle => vehicle.Color)
                                .Include(vehicle => vehicle.Transmission)
                                .Include(vehicle => vehicle.Image)
                                .Include(vehicle => vehicle.VehicleLocation)
                                .Include(vehicle => vehicle.Status)
                                .First();

            var vehicleDto = new VehicleDto(singleVehicle);

            return vehicleDto;
        }

        public IEnumerable<Vehicle> GetVehiclesByUserId(string userGuid)
        {
            var vehicles = _vehicleContext.Vehicles.Where(vehicle => vehicle.UserIdentityGuid == userGuid)
                                .Include(vehicle => vehicle.ModelYear)
                                    .ThenInclude(v => v.Model)
                                    .ThenInclude(v => v.Manufacturer)
                                .Include(vehicle => vehicle.Color)
                                .Include(vehicle => vehicle.Transmission)
                                .Include(vehicle => vehicle.Image)
                                .Include(vehicle => vehicle.VehicleLocation)
                                .Include(vehicle => vehicle.Status);

            return vehicles;
        }
    }
}