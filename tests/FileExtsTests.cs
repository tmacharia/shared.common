using System;
using System.Collections.Generic;
using System.Text;
using Common.IO;
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
            Assert.IsNotNull(validFileName);
            Assert.IsFalse(FileExts.IsFileNameValid(invalidFileName));
            Assert.IsTrue(FileExts.IsFileNameValid(validFileName));
        }
    }
}