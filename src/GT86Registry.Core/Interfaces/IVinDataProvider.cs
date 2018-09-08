using GT86Registry.Core.Models.ApiResponses;
using System.Threading.Tasks;

namespace GT86Registry.Core.Models
{
    public interface IVinDataProvider
    {
        Task<Result> LoadDataForVin(string vin);
    }
}
