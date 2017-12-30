using GT86Registry.Core.Entities;
using GT86Registry.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace GT86Registry.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, ISocialMediaLinks
    {
        public ApplicationUser()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        // Extend the existing Identity user information here

        public string City { get; set; }

        public string Country { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public string FacebookUri { get; set; }

        public string FirstName { get; set; }

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

        public string InstagramUri { get; set; }

        public DateTimeOffset LastActivityDate { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }
    }
}