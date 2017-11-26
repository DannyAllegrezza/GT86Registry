using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// VehicleModel represents a specific model vehicle. For example, "240SX" or "BRZ"
    /// </summary>
    public class VehicleModel : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Manufacturer Manufacturer { get; set; }

        public VehicleModelTrim Trim { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int FactoryWeight { get; set; }

        #region EF Navigation Properties
        public List<VehicleModelYear> VehicleModelYear { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        #endregion EF Navigation Properties

    }
}