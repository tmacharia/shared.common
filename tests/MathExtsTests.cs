using System;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class MathExtsTests
    {
        [Theory]
        [TestCase(arg1: 1, arg2: true)]
        [TestCase(arg1: 2, arg2: true)]
        [TestCase(arg1: 0, arg2: true)]
        [TestCase(arg1: -1, arg2: false)]
        public void CheckIf_Int_IsPositive(int i, bool ans)
        {
            // Act
            bool isPositive = i.IsPositive();

            // Assert
            Assert.Equals(ans, isPositive);
        }
        [Theory]
        [TestCase(arg1: 1, arg2: true)]
        [TestCase(arg1: 2.5, arg2: true)]
        [TestCase(arg1: 0.5, arg2: true)]
        [TestCase(arg1: -1.5, arg2: false)]
        public void CheckIf_Decimal_IsPositive(decimal d, bool ans)
        {
            // Act
            bool isPositive = d.IsPositive();

            // Assert
            Assert.Equals(ans, isPositive);
        }
        [Theory]
        [TestCase(arg1: 1, arg2: true)]
        [TestCase(arg1: 2.5, arg2: true)]
        [TestCase(arg1: 0.5, arg2: true)]
        [TestCase(arg1: -1.5, arg2: false)]
        public void CheckIf_Double_IsPositive(double d, bool ans)
        {
            // Act
            bool isPositive = d.IsPositive();

            // Assert
            Assert.Equals(ans, isPositive);
        }
    }
}