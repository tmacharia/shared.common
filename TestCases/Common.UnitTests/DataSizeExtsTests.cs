using System;
using Common.Enums;
using Common.Primitives;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class DataSizeExtsTests
    {
        [Theory]
        [TestCase(arg1: 0,arg2: null)]
        [TestCase(arg1: 1024, arg2: DataFormat.KB)]
        [TestCase(arg1: 1000000, arg2: DataFormat.MB)]
        [TestCase(arg1: 1000000000, arg2: DataFormat.GB)]
        [TestCase(arg1: 1000000000000, arg2: DataFormat.TB)]
        public void HumanizeDataSize(long dataSize, DataFormat? format)
        {
            // Act
            string result = dataSize.HumanizeData(format);

            // Assert
            Assert.IsNotNull(result);
            Console.WriteLine(result);
            Assert.IsTrue(result.EndsWith(format.ToString()));
        }
    }
}