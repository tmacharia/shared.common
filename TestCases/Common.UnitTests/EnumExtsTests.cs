using System;
using System.Collections.Generic;
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
        [Test]
        public void ForNonEnumType_GetEnumPairs_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => EnumExts.GetEnumPairs(typeof(Country)));
        }
        [Theory]
        [TestCase(typeof(DataFormat))]
        [TestCase(typeof(HttpVerb))]
        [TestCase(typeof(Enums.Country))]
        public void GetEnumPairs_AsDictionary(Type enumType)
        {
            // Act
            Dictionary<string, int> pairs = EnumExts.GetEnumPairs(enumType);

            // Assert
            Assert.Greater(pairs.Count, 0);
            pairs.ForEach(x => {
                Console.WriteLine("{0}: {1}", x.Key, x.Value);
            });
        }
    }
}