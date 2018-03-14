using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;

namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for vehicle view models.
    /// </summary>
    public interface IVehicleViewModel
    {
        ApplicationUser VehicleOwner {get;set;}
        Vehicle Vehicle {get;set;}
    }
}
