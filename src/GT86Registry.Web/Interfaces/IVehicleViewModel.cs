using GT86Registry.Core.Entities;
using GT86Registry.Infrastructure.Identity;

namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for vehicle view models.
    /// </summary>
    public interface IVehicleViewModel
    {
        Vehicle Vehicle { get; set; }
        ApplicationUser VehicleOwner { get; set; }
    }
}