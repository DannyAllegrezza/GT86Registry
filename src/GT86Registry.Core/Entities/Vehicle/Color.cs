using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string HexValue { get; set; }

        #region Constructors

        protected Color()
        {
        }

        public Color(string name, string code)
        {
            Name = name;
            Code = code;
        }

        #endregion Constructors

        #region Navigation Properties

        public virtual List<ColorsModelYears> ModelColors { get; set; } = new List<ColorsModelYears>();
        public virtual List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        #endregion Navigation Properties
    }
}