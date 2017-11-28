using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Transmission : BaseEntity
    {
        public int Id { get; set; }
        public TransmissionTypes Name { get; set; }
        public List<ModelTransmissions> ModelTransmissions { get; set; }
    }

    public enum TransmissionTypes
    {
        Automatic,
        Manual
    }
}