namespace GT86Registry.Core.Entities
{
    public class ModelTransmissions : BaseEntity
    {
        public ModelYear ModelYear { get; set; }
        public int ModelYearId { get; set; }
        public Transmission Transmission { get; set; }
        public int TransmissionId { get; set; }
    }
}