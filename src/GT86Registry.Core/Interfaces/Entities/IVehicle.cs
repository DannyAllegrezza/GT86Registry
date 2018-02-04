using GT86Registry.Core.Entities;
using System.Collections.Generic;

namespace GT86Registry.Core.Interfaces.Entities
{
    public interface IVehicle
    {
        Color Color { get; set; }
        int ColorId { get; set; }
        string Description { get; set; }
        string FacebookUri { get; set; }
        Image Image { get; set; }
        string InstagramUri { get; set; }
        int Mileage { get; set; }
        ModelYear ModelYear { get; set; }
        int ModelYearId { get; set; }
        int ProfilePhotoId { get; set; }
        VehicleStatus Status { get; set; }
        int StatusId { get; set; }
        Transmission Transmission { get; set; }
        int TransmissionId { get; set; }
        string UserIdentityGuid { get; set; }
        List<VehiclesImages> VehicleImages { get; set; }
        VehicleLocation VehicleLocation { get; set; }
        int VehicleLocationId { get; set; }
        int ViewCount { get; set; }
        string VIN { get; set; }
    }
}