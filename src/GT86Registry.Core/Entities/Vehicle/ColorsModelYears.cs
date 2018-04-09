namespace GT86Registry.Core.Entities
{
    public class ColorsModelYears : BaseEntity
    {
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public ModelYear ModelYear { get; set; }
        public int ModelYearId { get; set; }
    }
}