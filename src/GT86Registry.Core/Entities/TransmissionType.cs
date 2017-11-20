namespace GT86Registry.Core.Entities
{
    public class TransmissionType : BaseEntity
    {

        public int Id { get; set; }
        public TransmissionTypes Name { get; set; }
    }

    public enum TransmissionTypes
    {
        Automatic,
        Manual
    }
}