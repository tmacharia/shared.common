using Common.Enums;

namespace Common.Primitives
{
    /// <summary>
    /// Represents extension methods for currency formatting.
    /// </summary>
    public static class CurrencyExts
    {
        private const bool _useFormat = true;
        #region Currency Methods
        /// <summary>
        /// Formats an <see cref="int"/> to currency <see cref="string"/> using the currency symbol of the 
        /// country where this device is located.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string ToLocalCurrency(this int n)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} {n.ToString($"N0", Constants.Culture)}";
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> to currency <see cref="string"/> using the currency symbol of the 
        /// country where this device is located.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="precision">Number of decimal places to use.</param>
        /// <returns></returns>
        public static string ToLocalCurrency(this decimal d,int precision=2)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} {d.ToString($"N{precision}", Constants.Culture)}";
        }
        /// <summary>
        /// Formats a <see cref="float"/> to currency <see cref="string"/> using the currency symbol of the 
        /// country where this device is located.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="precision">Number of decimal places to use.</param>
        /// <returns></returns>
        public static string ToLocalCurrency(this float f, int precision = 2)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} {f.ToString($"N{precision}", Constants.Culture)}";
        }
        #endregion
        #region Current Methods
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="decimal"/> if it has any.
        /// </param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this decimal d, bool useFormat = true)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to a specific country's currency symbol with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="country">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this decimal d, Country country = Country.US)
        {
            return $"{country.GetSymbolAttribute()} " + (_useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="country">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="decimal"/> if it has any.
        /// </param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this decimal d, Country country = Country.US, bool useFormat = true)
        {
            return $"{country.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="double"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="double"/> if it has any.
        /// </param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this double d, bool useFormat = true)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="double"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="country">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this double d, Country country = Country.US)
        {
            return $"{country.GetSymbolAttribute()} " + (_useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="double"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="country">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="double"/> if it has any.
        /// </param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this double d, Country country = Country.US, bool useFormat = true)
        {
            return $"{country.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency.
        /// </summary>
        /// <param name="n">Integer amount to format.</param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this int n)
        {
            return $"{ZoneExts.CurrentCountry.GetSymbolAttribute()} " + n.ToString(n % 1 == 0 ? "N0" : "N2", Constants.Culture);
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency.
        /// </summary>
        /// <param name="n">Integer amount to format.</param>
        /// <param name="country">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <returns>Formatted value as currency.</returns>
        public static string ToMoney(this int n, Country country = Country.US)
        {
            return $"{country.GetSymbolAttribute()} " + n.ToString(n % 1 == 0 ? "N0" : "N2", Constants.Culture);
        }
        #endregion
    }
}