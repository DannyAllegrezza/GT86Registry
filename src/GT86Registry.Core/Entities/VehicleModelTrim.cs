using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class VehicleModelTrim : BaseEntity
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
