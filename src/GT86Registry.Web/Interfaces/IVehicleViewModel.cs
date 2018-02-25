namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for vehicle view models.
    /// </summary>
    public class IVehicleViewModel
    {
        /// <summary>
        /// The Identity GUID of the Vehicle's owner
        /// </summary>
        public string UserIdentityGuid { get; set; }

        /// <summary>
        /// The Vehicle Information Number
        /// </summary>
        public string VIN { get; set; }
    }
}
