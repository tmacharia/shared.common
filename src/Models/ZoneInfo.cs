namespace System.Globalization
{
    using System.Linq;
    /// <summary>
    /// Represents TimeZone information
    /// </summary>
    public class ZoneInfo
    {
        /// <summary>
        /// 2-Letter ISO code representing the country where the timezone is.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The general name of the timezone.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Name of the city
        /// </summary>
        public string City => string.IsNullOrWhiteSpace(Name) ? string.Empty : Name.Split(' ').Last();
    }
}