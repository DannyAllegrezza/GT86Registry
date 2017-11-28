using GT86Registry.Core.Entities;
using GT86Registry.Core.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Core.Entities
{
    [TestClass]
    public class VINTests
    {
        private string InvalidVin { get; set; }
        private string ValidVin { get; set; }

        [TestInitialize]
        public void Init()
        {
            InvalidVin = "JF1ZCAC18H960322_";
            ValidVin = "JF1ZCAC18H9603221";
        }

        [TestMethod]
        public void VIN_IsValid()
        {
            Assert.IsTrue(VIN.IsValid(ValidVin));
        }

        [TestMethod]
        public void VIN_ThrowsException_WhenInputIsTooShort()
        {
            Assert.IsFalse(VIN.IsValid(InvalidVin));
        }

        [TestMethod]
        public void VIN_ReturnsFalse_WhenNull()
        {
            string nullVIN = null;
            Assert.IsFalse(VIN.IsValid(nullVIN));
        }
    }
}
