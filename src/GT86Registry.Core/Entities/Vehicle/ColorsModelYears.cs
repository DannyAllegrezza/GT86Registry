namespace GT86Registry.Core.Entities
{
    public class ColorsModelYears : BaseEntity
    {
        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int ModelYearId { get; set; }
        public ModelYear ModelYear { get; set; }
        
    }
}