using Common.Enums;

namespace Common.Primitives
{
    /// <summary>
    /// Represents extension methods for currency formatting.
    /// </summary>
    public static class CurrencyExts
    {
        #region Current Methods
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="currency">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="decimal"/> if it has any.
        /// </param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this decimal d, CurrencyType currency = CurrencyType.USD, bool useFormat = true)
        {
            return $"{currency.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="double"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="currency">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is True to perform formatting. Choosing False
        /// will retain all the decimals places in a <see cref="double"/> if it has any.
        /// </param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this double d, CurrencyType currency = CurrencyType.USD, bool useFormat = true)
        {
            return $"{currency.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency.
        /// </summary>
        /// <param name="n">Integer amount to format.</param>
        /// <param name="currency">Currency Type to format the result to. Defaults to USD if not set.</param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this int n, CurrencyType currency = CurrencyType.USD)
        {
            return $"{currency.GetSymbolAttribute()} " + n.ToString(n % 1 == 0 ? "N0" : "N2", Constants.Culture);
        }
        #endregion
    }
}