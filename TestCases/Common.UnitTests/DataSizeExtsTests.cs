using System;
using System.Linq;
using Common.Enums;
using Common.Primitives;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class DataSizeExtsTests : TestData
    {
        [Test]
        public void TestDataSizeConstants()
        {
            // Arrange
            double kb = 1000,
                   mb = 1000000,
                   gb = 1000000000,
                   tb = 1000000000000;

            // Assert
            Assert.AreEqual(kb, DataSizeExts.OneKb);
            Assert.AreEqual(mb, DataSizeExts.OneMb);
            Assert.AreEqual(gb, DataSizeExts.OneGb);
            Assert.AreEqual(tb, DataSizeExts.OneTb);
        }
        [Theory]
        [TestCase(arg1: 1000, arg2: DataFormat.KB)]
        [TestCase(arg1: 1000000, arg2: DataFormat.MB)]
        [TestCase(arg1: 1000000000, arg2: DataFormat.GB)]
        [TestCase(arg1: 1000000000000, arg2: DataFormat.TB)]
        public void TestZerosCount_On_HumanizeDataSize(long dataSize, DataFormat format)
        {
            // Act
            string res = dataSize.HumanizeData(DataFormat.Bytes, 0);

            // Assert
            Assert.IsNotNull(res);
            Log(res);
            Assert.AreEqual((int)format, res.Count(c => c == '0'));
        }
        [Theory]
        [TestCase(arg1: 0,arg2: null)]
        [TestCase(arg1: 1024, arg2: DataFormat.KB)]
        [TestCase(arg1: 1000000, arg2: DataFormat.MB)]
        [TestCase(arg1: 1000000000, arg2: DataFormat.GB)]
        [TestCase(arg1: 1000000000000, arg2: DataFormat.TB)]
        public void HumanizeDataSize(long dataSize, DataFormat? format)
        {
            // Arrange
            format = format.HasValue ? format : DataFormat.Bytes;

            // Act
            string result = dataSize.HumanizeData(format);

            // Assert
            Assert.IsNotNull(result);
            Log(result);
            Assert.IsTrue(result.EndsWith(format.ToString()));
        }
    }
}