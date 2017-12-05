using GT86Registry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Infrastructure.Data
{
    public class VehicleRepository : EFRepository<Vehicle>
    {
        public VehicleRepository(VehicleDbContext vehicleContext) : base(vehicleContext)
        {
        }


    }
}
