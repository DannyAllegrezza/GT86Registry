namespace GT86Registry.Core.Entities
{
    public class ModelTransmissions : BaseEntity
    {
        public int ModelYearId { get; set; }
        public ModelYear ModelYear { get; set; }

        public int TransmissionId { get; set; }
        public Transmission Transmission { get; set; }
    }
}