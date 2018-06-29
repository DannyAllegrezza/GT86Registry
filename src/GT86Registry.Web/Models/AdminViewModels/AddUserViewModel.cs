using GT86Registry.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GT86Registry.Web.Models.AdminViewModels
{
    public class AddUserViewModel
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string ProfileDescription { get; set; }

        public string FacebookUri { get; set; }

        public string InstagramUri { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

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

        public string PostalCode { get; set; }

        public string ProfilePhotoUri { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string State { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string UserName { get; set; }
    }
}
