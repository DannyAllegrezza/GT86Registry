using GT86Registry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vin, int modelYearId, int colorId, int transmissionId, string userIdentityGuid);
        Vehicle CreateVehicle(string vin, ModelYear modelYear, Color colorId, Transmission transmissionId, string userIdentityGuid);
    }
}
