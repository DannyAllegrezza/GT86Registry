using System.Collections.Generic;

namespace GT86Registry.Infrastructure.Identity
{
    public class ApplicationRoles
    {
        public const string AdministratorRole = "Administrators";
        public const string ModeratorRole = "Moderators";
        public const string MemberRole = "Members";

        public static List<string> Roles = new List<string>() { AdministratorRole, ModeratorRole, MemberRole };
    }
}
