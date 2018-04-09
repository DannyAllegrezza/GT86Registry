using GT86Registry.Web.Interfaces.Services;
using System.Threading.Tasks;

namespace GT86Registry.Web.Interfaces
{
    /// <summary>
    /// Interface for User Profile Services.
    ///
    /// <para>The User Profile Service is responsible for fetching a registered User's profile and their associated vehicles.</para>
    /// </summary>
    public interface IUserProfileService
    {
        Task<IUserProfileViewModel> GetProfileByUsername(string username);
    }
}