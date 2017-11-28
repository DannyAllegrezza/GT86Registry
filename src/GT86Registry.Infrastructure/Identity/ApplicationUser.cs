using GT86Registry.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GT86Registry.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, ISocialMediaLinks
    {
        // Extend the existing Identity user information here
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string InstagramUri { get; set; }

        public string FacebookUri { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
    }
}