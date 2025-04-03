using System;
using System.IO;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class StreamExtsTests
    {
        [Test]
        public void ConvertStreamToArray()
        {
            // Arrange
            Stream stream = new MemoryStream(new byte[1]);
            // Act
            byte[] bytes = stream.ToArray();
            // Assert
            Assert.That(bytes.Length == 0, Is.False);
            Assert.That(bytes.Length == stream.Length, Is.True);
        }
        [Test]
        public void ConvertStreamToArray_If_StreamIsNull_ThrowsException()
        {
            // Arrange; 
            Stream stream = null;
            // Act; Assert
            Assert.Throws<ArgumentNullException>(() => stream.ToArray());
        }
    }
}
