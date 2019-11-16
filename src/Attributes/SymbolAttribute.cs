using System;

namespace Common.Attributes
{
    /// <summary>
    /// Specifies a symbol for a property/field or event.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class SymbolAttribute : Attribute
    {
        /// <summary>
        /// Instanciates attributes with a symbol value.
        /// </summary>
        /// <param name="symbolValue"></param>
        public SymbolAttribute(string symbolValue)
        {
            if (!string.IsNullOrWhiteSpace(symbolValue))
                Symbol = symbolValue;
        }
        /// <summary>
        /// Value of symbol.
        /// </summary>
        public string Symbol { get; set; }
    }
}