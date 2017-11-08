using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GT86Registry.Core.Entities
{
    /// <summary>
    /// CarModel represents a specific model vehicle. For example, "240SX" or "BRZ"
    /// </summary>
    public class CarModel : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Manufacturer Manufacturer { get; set; }

        public int FactoryWeight { get; set; }

        public TransmissionType Transmission { get; set; }

        #region EF Navigation Properties
        public List<Car> Cars { get; set; }
        #endregion 
    }

    public enum TransmissionType
    {
        Automatic,
        Manual
    }
}
