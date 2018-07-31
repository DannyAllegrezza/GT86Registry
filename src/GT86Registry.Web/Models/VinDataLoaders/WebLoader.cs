using GT86Registry.Core.Models;
using GT86Registry.Core.Models.ApiResponses;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GT86Registry.Web.Models.VinDataLoaders
{
    public class WebLoader : IVinDataProvider
    {        
        public async Task<Result> LoadDataForVin(string vin)
        {
            var client = new HttpClient();
            var endpoint = NhtsaGovUri.BuildUrl(vin);

            var response = await client.GetAsync(endpoint);
            var content = await response.Content.ReadAsAsync<DepartmentOfTransportationApiResponse>();

            var result = content.Results.FirstOrDefault();

            if (!string.IsNullOrEmpty(result.AdditionalErrorText))
            {
                return null;
            }

            return result;
        }
    }

    public static class NhtsaGovUri
    {
        public static string BuildUrl(string vin)
        {
            return $"https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvalues/{vin}?format=json";
        }
    }
}
