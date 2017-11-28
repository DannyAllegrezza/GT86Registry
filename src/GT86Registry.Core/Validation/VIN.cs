using System.Text.RegularExpressions;

namespace GT86Registry.Core.Validation
{
    public static class VIN
    {
        public static bool IsValid(string vin)
        {
            return (vin == null) ? false : Regex.IsMatch(vin, @"[A-HJ-NPR-Z0-9]{13}[0-9]{4}");
        }
    }
}