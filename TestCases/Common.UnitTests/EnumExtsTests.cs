using System;
using Common.Enums;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class EnumExtsTests
    {
        [Test]
        public void GetNameOf_SelectedEnum()
        {
            // Arrange
            DataFormat format = DataFormat.Bytes;

            // Act
            string name = format.GetName();

            // Assert
            Assert.IsNotNull(name);
            Console.WriteLine(name);
        }
    }
}