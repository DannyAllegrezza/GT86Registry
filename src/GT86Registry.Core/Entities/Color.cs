using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Color : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

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

        public List<ColorsModelYears> ModelColors { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        #endregion Navigation Properties
    }
}