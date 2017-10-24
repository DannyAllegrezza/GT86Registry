using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }

        [MaxLength(3)]
        public string Code { get; set; }

        public int ManufactuerId { get; set; }

        public Manufactuer Manufactuer { get; set; }

        public List<ColorsYears> ColorYears { get; set; }
    }
}