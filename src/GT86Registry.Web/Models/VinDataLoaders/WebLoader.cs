using GT86Registry.Core.Models;
using GT86Registry.Core.Models.ApiResponses;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GT86Registry.Web.Models.VinDataLoaders
{
    public class WebLoader : IVinDataProvider
    {
        private string _url { get; }

        public WebLoader(string url)
        {
            _url = url;
        }
        
        public async Task<Result> LoadDataForVin(string vin)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(_url);
            var content = await response.Content.ReadAsAsync<DepartmentOfTransportationApiResponse>();

            return content.Results.FirstOrDefault();
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
