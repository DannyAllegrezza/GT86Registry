using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces.Entities;

namespace GT86Registry.Core.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string vin, int modelYearId, int colorId, int transmissionId, string userIdentityGuid);

        IVehicle CreateVehicle(string vin, ModelYear modelYear, Color colorId, Transmission transmissionId, string userIdentityGuid);
    }
}