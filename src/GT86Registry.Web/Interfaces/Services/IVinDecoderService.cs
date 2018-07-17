using GT86Registry.Core.Models.ApiResponses;
using System.Threading.Tasks;

namespace GT86Registry.Web.Interfaces
{
    public interface IVinDecoderService
    {
        Task<Result> GetDecodedVin(string vin);
    }
}
