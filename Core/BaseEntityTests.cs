using GT86Registry.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core
{
    [TestClass]
    public class BaseEntityTests
    {
        [TestMethod]
        public void TestBaseEntityConstructorIsCalled()
        {
            var brz = new Car();
        }
    }
}
