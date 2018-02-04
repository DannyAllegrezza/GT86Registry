using GT86Registry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GT86Registry.Core.Entities;
using System.Linq;
using GT86Registry.Core.Interfaces.Entities;

namespace GT86Registry.Core.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        private IRepository<Vehicle> _vehicleRepo;
        private IRepository<VehicleStatus> _vehicleStatusRepo;

        public VehicleFactory(IRepository<Vehicle> vehicleRepo, IRepository<VehicleStatus> vehicleStatusRepo)
        {
            _vehicleRepo = vehicleRepo;
            _vehicleStatusRepo = vehicleStatusRepo;
        }

        public IVehicle CreateVehicle(string vin, int modelYearId, int colorId, int transmissionId, string userIdentityGuid)
        {
            //todo(dca): always first insert all objects to which the vehicle is the FK (Status, Image, etc)
            var status = _vehicleStatusRepo.GetAllQueryable().Where(x => x.Name == Status.TrackCar.ToString()).First();

            Vehicle userVehicle = new Vehicle(vin)
            {
                ModelYearId = modelYearId,
                ColorId = colorId,
                TransmissionId = transmissionId,
                UserIdentityGuid = userIdentityGuid,
                //todo(dca): remove these test values below - but keep in mind they are all required to construct a Vehicle in a valid state
                ProfilePhotoId = 2,
                VehicleLocationId = 3,
                Description = "Test description",
                Mileage = 10000,
                Status = status
            };

            _vehicleRepo.Add(userVehicle);

            return userVehicle;
        }

        public IVehicle CreateVehicle(string vin, ModelYear modelYear, Color colorId, Transmission transmissionId, string userIdentityGuid)
        {
            IVehicle vehicle = new Vehicle(vin, modelYear, colorId, transmissionId, userIdentityGuid);

            return vehicle;
        }
    }
}
