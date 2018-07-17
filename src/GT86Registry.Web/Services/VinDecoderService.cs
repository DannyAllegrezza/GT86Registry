using GT86Registry.Core.Models;
using GT86Registry.Core.Models.ApiResponses;
using GT86Registry.Web.Interfaces;
using System.Threading.Tasks;

namespace GT86Registry.Web.Services
{
    public class VinDecoderService : IVinDecoderService
    {
        private readonly IVinDataProvider _loader;

        public VinDecoderService(IVinDataProvider loader)
        {
            _loader = loader;
        }

        public async Task<Result> GetDecodedVin(string vin)
        {
            var data = await _loader.LoadDataForVin(vin);
            return data;
        }
    }
}
