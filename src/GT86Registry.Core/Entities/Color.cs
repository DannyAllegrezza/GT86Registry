using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }

        [MaxLength(3)]
        public string Code { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public List<ColorsYears> ColorYears { get; set; }
    }
}