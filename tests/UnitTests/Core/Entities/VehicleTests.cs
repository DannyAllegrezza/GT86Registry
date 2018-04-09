using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Core.Entities
{
    [TestClass]
    public class VehicleTests
    {
        private const string _vin = "JF1ZCAC11E9603184";
        private IVehicleFactory _vehicleFactory;

        [TestInitialize]
        public void Setup()
        {
            //_vehicleFactory = new VehicleFactory();
        }

        [TestMethod]
        public void Vehicle_IsCreated_InValidState()
        {
            // todo(dca): mock this out
            Model model = new Model("Sbuaru", 1);
            Color color = new Color("World Rally Blue", "123");
            Transmission transmission = new Transmission("6-Spd Manual");
            ModelYear modelYear = new ModelYear(2015, model.Id);
            string userIdentityGuid = "1235acb";

            //Vehicle vehicle = _vehicleFactory.CreateVehicle(_vin, modelYear, color, transmission, userIdentityGuid);

            //Assert.IsNotNull(vehicle);
        }
    }
}