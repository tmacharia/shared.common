using System.IO;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class FileExtsTests
    {
        [Theory]
        [TestCase(arg1: "", arg2: false)]
        [TestCase(arg1: "8:35 PM", arg2: false)]
        [TestCase(arg1: "0835 PM", arg2: true)]
        public void CheckIfFileName_IsValid(string fileName, bool answer)
        {
            // Act
            bool isValid = FileExts.IsFileNameValid(fileName);

            // Assert
            Assert.AreEqual(answer, isValid);
        }
        [Theory]
        [TestCase("8:35 PM")]
        public void ConvertFileName_ToSafeFileName_ShouldPass_IsValidFileNameTest(string invalidFileName)
        {
            // Act
            string validFileName = FileExts.ToSafeFileName(invalidFileName);

            // Assert
            Assert.That(validFileName, Is.Not.Null);
            Assert.That(FileExts.IsFileNameValid(invalidFileName), Is.False);
            Assert.That(FileExts.IsFileNameValid(validFileName), Is.True);
        }
    }
}
