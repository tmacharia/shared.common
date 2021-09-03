using System.Formatting;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class CurrencyExtsTests : TestData
    {
        [Theory]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.US, arg3: "$")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.NG, arg3: "₦")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.JP, arg3: "¥")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.GB, arg3: "£")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.UG, arg3: "USh")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.LS, arg3: "R")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.ZA, arg3: "R")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.FR, arg3: "€")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.KE, arg3: "Ksh")]
        [TestCase(arg1: 3500.8765, arg2: System.Formatting.Country.SE, arg3: "kr")]
        public void FormatCurrency(double d, System.Formatting.Country type, string symbol)
        {
            // Act
            string res = d.ToMoney(type);

            // Assert
            Log(res);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.StartsWith(symbol));
        }
    }
}