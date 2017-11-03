using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class CarModel : BaseEntity
    {
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public List<Car> Cars { get; set; }
    }
}
