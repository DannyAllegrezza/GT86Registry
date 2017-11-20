using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(3)]
        public string Code { get; set; }

        public List<ColorsYears> ColorYears { get; set; }
    }
}