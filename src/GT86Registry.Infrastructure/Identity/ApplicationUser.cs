using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GT86Registry.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        // Extend the existing Identity user information here
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
