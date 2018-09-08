using GT86Registry.Core.Models;
using GT86Registry.Core.Models.ApiResponses;
using GT86Registry.Web.Interfaces;
using GT86Registry.Web.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace GT86Registry.Web.Services
{
    /// <summary>
    /// Service to decode VINs by calling the provided VinDataProvider
    /// </summary>
    public class VinDecoderService : IVinDecoderService
    {
        private readonly IVinDataProvider _loader;
        private readonly IOptions<SiteSettingsConfiguration> _siteConfig;

        public VinDecoderService(IVinDataProvider loader, IOptions<SiteSettingsConfiguration> siteConfig)
        {
            _loader = loader;
            _siteConfig = siteConfig;
        }

        public async Task<Result> GetDecodedVin(string vin)
        {
            var data = await _loader.LoadDataForVin(vin);

            data.IsValidForSite = IsVehicleValidForSiteInstance(data.Make);

            return data;
        }

        /// <summary>
        /// Valides that the VIN was for a vehicle manufacturer that is in the site config
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <returns></returns>
        public bool IsVehicleValidForSiteInstance(string manufacturer)
        {
            var manufacturers = _siteConfig.Value.Manufacturers.ToList();
            return manufacturer.ToLower().Contains(manufacturer.ToLower());
        }
    }
}
