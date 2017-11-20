using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// Represents a vehicle Manufacturer such a "Subaru", "Toyota" or "Scion"
    /// </summary>
    public class Manufacturer : BaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInProduction { get; set; }

        public List<VehicleModel> VehicleModels { get; set; }
    }
}