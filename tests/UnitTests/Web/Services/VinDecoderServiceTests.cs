using GT86Registry.Web.Models.VinDataLoaders;
using GT86Registry.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace UnitTests.Web.Services
{
    [TestClass]
    public class VinDecoderServiceTests
    {
        private string _vin = "JF1ZCAC11E9603184";

        [TestMethod]
        public async Task GetDecodedVin_DecodesCorrectly_WhenVinIsValid()
        {
            var webLoader = new WebLoader();

            var service = new VinDecoderService(webLoader, null);

            var result = await service.GetDecodedVin(_vin);

            Assert.IsNotNull(result);
        }
    }
}
