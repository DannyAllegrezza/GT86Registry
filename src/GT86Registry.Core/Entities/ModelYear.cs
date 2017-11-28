using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class ModelYear : BaseEntity
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public Model Model { get; set; }
        public int ModelId { get; set; }

        public List<ModelTransmissions> ModelTransmissions { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<ColorsModelYears> ModelColors { get; set; }
    }
}
