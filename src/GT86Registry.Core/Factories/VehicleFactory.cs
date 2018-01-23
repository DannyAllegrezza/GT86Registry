using GT86Registry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GT86Registry.Core.Entities;

namespace GT86Registry.Core.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vin, int modelYearId, int colorId, int transmissionId, string userIdentityGuid)
        {
            throw new NotImplementedException();
        }

        public Vehicle CreateVehicle(string vin, ModelYear modelYear, Color colorId, Transmission transmissionId, string userIdentityGuid)
        {
            Vehicle vehicle = new Vehicle(vin, modelYear, colorId, transmissionId, userIdentityGuid);

            return vehicle;
        }
    }
}
