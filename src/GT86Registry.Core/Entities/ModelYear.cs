using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Core.Entities
{
    public class ModelYear : BaseEntity
    {
        public int Id { get; set; }

        public int Year { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new ModelYear
        /// </summary>
        /// <param name="year">The vehicle model year</param>
        /// <param name="modelId">The Id of the vehicle Model associated with this Year.</param>
        public ModelYear(int year, int modelId)
        {
            Year = year;
            ModelId = modelId;
        }

        public ModelYear(int year, Model model)
        {
            Year = year;
            Model = model;
        }

        #endregion Constructors

        #region Navigation Properties

        public Model Model { get; set; }
        public int ModelId { get; set; }
        public List<ModelTransmissions> ModelTransmissions { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<ColorsModelYears> ModelColors { get; set; }
        
        #endregion Navigation Properties
    }
}
