using GT86Registry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GT86Registry.Core.Entities;

namespace GT86Registry.Core.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        private IRepository<Vehicle> _vehicleRepo;

        public VehicleFactory(IRepository<Vehicle> vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public Vehicle CreateVehicle(string vin, int modelYearId, int colorId, int transmissionId, string userIdentityGuid)
        {
            Vehicle userVehicle = new Vehicle(vin)
            {
                ModelYearId = modelYearId,
                ColorId = colorId,
                TransmissionId = transmissionId,
                UserIdentityGuid = userIdentityGuid,
                //todo(dca): remove these test values below
                ProfilePhotoId = 2,
                VehicleLocationId = 3,
                Description = "Test description",
                Mileage = 10000,
            };

            _vehicleRepo.Add(userVehicle);

            return userVehicle;
        }

        public Vehicle CreateVehicle(string vin, ModelYear modelYear, Color colorId, Transmission transmissionId, string userIdentityGuid)
        {
            Vehicle vehicle = new Vehicle(vin, modelYear, colorId, transmissionId, userIdentityGuid);

            return vehicle;
        }
    }
}
