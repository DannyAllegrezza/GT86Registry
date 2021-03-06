﻿using System.Collections.Generic;

namespace GT86Registry.Core.Entities
{
    public class Transmission : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Constructors

        public Transmission()
        {
        }

        public Transmission(string name)
        {
            Name = name;
        }

        #endregion Constructors

        #region Navigation Properties

        public List<ModelTransmissions> ModelTransmissions { get; set; }

        #endregion Navigation Properties
    }
}