using System;
using System.Collections.Generic;
using System.Extensions;
using System.Formatting;
using System.Linq;
using Common.Enums;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class EnumExtsTests : TestData
    {
        [Test]
        public void GetNameOf_SelectedEnum()
        {
            // Arrange
            DataFormat format = DataFormat.Bytes;

            // Act
            string name = format.GetName();

            // Assert
            Assert.That(name, Is.Not.Null);
            Log(name);
        }
        [Test]
        public void ForNonEnumType_GetEnumPairs_ThrowsException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => EnumExts.GetEnumPairs(typeof(Country)));
        }
        [Theory]
        [TestCase(arg1: "KB", arg2: 3, arg3: typeof(DataFormat))]
        [TestCase(arg1: "MB", arg2: 6, arg3: typeof(DataFormat))]
        [TestCase(arg1: "GB", arg2: 9, arg3: typeof(DataFormat))]
        [TestCase(arg1: "TB", arg2: 12, arg3: typeof(DataFormat))]
        public void GetEnumName_ProvidedItsValue(string enumName, long value, Type enumType)
        {
            // Act
            string result = EnumExts.GetName(enumType, value);

            // Assert
            Assert.AreEqual(enumName, result);
        }

        [Theory]
        [TestCase(typeof(DataFormat))]
        [TestCase(typeof(HttpVerb))]
        [TestCase(typeof(System.Formatting.Country))]
        public void GetEnumPairs_AsDictionary(Type enumType)
        {
            // Act
            Dictionary<string, int> pairs = EnumExts.GetEnumPairs(enumType);

            // Assert
            Assert.That(pairs.Count, Is.GreaterThan(0));
            pairs.ForEach(x =>
            {
                Log("{0}: {1}", x.Key, x.Value);
            });
        }
    }
}
