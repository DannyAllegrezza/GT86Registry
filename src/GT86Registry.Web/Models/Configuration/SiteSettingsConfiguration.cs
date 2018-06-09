namespace GT86Registry.Web.Models.Configuration
{
    public class SiteSettingsConfiguration
    {
        public string[] Roles { get; set; }

        /// <summary>
        /// The name of the site (usually platform specific).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The manufacturers associated with the vehicle platform the site is focused on.
        /// </summary>
        public string[] Manufacturers { get; set; }

        /// <summary>
        /// The platform code for the vehicle which this site is focused on.
        /// </summary>
        public string VehiclePlatform { get; set; }
    }
}
