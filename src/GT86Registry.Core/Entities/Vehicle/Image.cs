using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string UserIdentityGuid { get; set; }

        #region Navigation Properties

        public List<VehiclesImages> VehicleImages { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        #endregion Navigation Properties
    }
}