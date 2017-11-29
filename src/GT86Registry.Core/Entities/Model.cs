using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// VehicleModel represents a specific model vehicle. For example, "240SX" or "BRZ"
    /// </summary>
    public class Model : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Constructors
        public Model(string modelName, int manufacturerId)
        {
            Name = modelName;
            ManufacturerId = manufacturerId;
        }
        #endregion Constructors

        #region EF Navigation Properties
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }

        public List<ModelYear> ModelYears { get; set; }
        #endregion EF Navigation Properties

    }
}