using System.Extensions;
using System.Linq;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class StringExtsTests : TestData
    {
        [Theory]
        #region Valid Email Test Cases
        [TestCase(arg1: "david.jones@proseware.com", arg2: true)]
        [TestCase(arg1: "d.j@server1.proseware.com", arg2: true)]
        [TestCase(arg1: "jones@ms1.proseware.com", arg2: true)]
        [TestCase(arg1: "j@proseware.com9", arg2: true)]
        [TestCase(arg1: "js#internal@proseware.com", arg2: true)]
        [TestCase(arg1: "j_9@[129.126.118.1]", arg2: true)]
        [TestCase(arg1: "js@proseware.com9", arg2: true)]
        [TestCase(arg1: "j.s@server1.proseware.com", arg2: true)]
        [TestCase(arg1: "\"j\"s\"\"@proseware.com", arg2: true)]
        [TestCase(arg1: "js@contoso.中国", arg2: true)]
        #endregion
        #region Invalid Email Test Cases
        [TestCase(arg1: "", arg2: false)]
        [TestCase(arg1: " ", arg2: false)]
        [TestCase(arg1: @"\", arg2: false)]
        [TestCase(arg1: "j.@server1.proseware.com", arg2: false)]
        [TestCase(arg1: "j..s@proseware.com", arg2: false)]
        [TestCase(arg1: "js*@proseware.com", arg2: false)]
        [TestCase(arg1: "js@proseware..com", arg2: false)]
        #endregion
        public void VerifyEmailFormat(string email, bool isEmailValid)
        {
            // Act
            bool result = email.IsEmailValid();

            // Assert
            Assert.AreEqual(isEmailValid, result);
        }

        [Theory]
        [TestCase(arg1: "", arg2: 5)]
        [TestCase(arg1: " ", arg2: 5)]
        [TestCase(arg1: "Message is a test", arg2: 5)]
        [TestCase(arg1: "This is a test message", arg2: 25)]
        public void TruncateText_By_CharacterCount(string text, int count)
        {
            // Arrange
            string trail = Constants.TrailingText;
            // Act
            string res = text.Shorten(count);

            // Assert
            Log(res);
            if (text.Length > count)
            {
                Assert.AreEqual(count + trail.Length, res.Length);
                Assert.That(res.EndsWith(trail), Is.True);
            }
            else
            {
                Assert.AreEqual(text, res);
                Assert.That(res.EndsWith(trail), Is.False);
            }
        }
        [Theory]
        [TestCase(arg1: "", arg2: 5)]
        [TestCase(arg1: " ", arg2: 5)]
        [TestCase(arg1: "Message is a test", arg2: 2)]
        [TestCase(arg1: "This is a test message ", arg2: 25)]
        [TestCase(arg1: " Asp.Net Core 2.1 is awesome", arg2: 3)]
        public void TruncateText_By_WordCount(string text, int count)
        {
            // Arrange
            string trail = Constants.TrailingText;
            int wordCount = text.WordCount();
            // Act
            string res = text.TruncateWords(count);

            // Assert
            Log(res);
            if (wordCount > count)
            {
                Assert.AreEqual(count, res.WordCount());
                Assert.That(res.EndsWith(trail), Is.True);
            }
            else
            {
                Assert.AreEqual(text, res);
            }
        }

        [Test]
        public void StartsWithAnyOf_ForValidTxt_ReturnsTrue()
        {
            // Arrange
            string txt = "/ke/controller/action";
            string[] args = new string[] { "/tz", "/us", "/ke" };

            // Act
            bool res = txt.StartsWithAnyOf(args);

            // Assert
            Assert.That(res, Is.True);
        }
        [Test]
        public void StartsWithAnyOf_ForInvalidTxt_ReturnsFalse()
        {
            // Arrange
            string txt = "/controller/action";
            string[] args = new string[] { "/tz", "/us", "/ke" };

            // Act
            bool res = txt.StartsWithAnyOf(args);

            // Assert
            Assert.That(res, Is.False);
        }

        [Test]
        public void String_ContainsAnyOf_ReturnsTrue()
        {
            // Arrange
            string txt = "This is after visting the company aa";
            string[] args = GetTwoLetter_Strings().ToArray();

            // Act
            bool res = txt.ContainsAnyOf(args);

            // Assert
            Assert.That(res, Is.True);
        }
        [Test]
        public void String_ContainsAnyOf_ReturnsFalse()
        {
            // Arrange
            string txt = "This is after visting the company";
            string[] args = GetTwoLetter_Strings().ToArray();

            // Act
            bool res = txt.ContainsAnyOf(args);

            // Assert
            Assert.That(res, Is.False);
        }
        [Test]
        public void String_ContainsAllOf_ReturnsTrue()
        {
            // Arrange
            string txt = "This is after visting the company aa,bb,cc,dd";
            string[] args = GetTwoLetter_Strings().ToArray();

            // Act
            bool res = txt.ContainsAll(args);

            // Assert
            Assert.That(res, Is.True);
        }
        [Test]
        public void String_ContainsAll_ReturnsFalse()
        {
            // Arrange
            string txt = "This is after visting the company aa,bb";
            string[] args = "aa,bb".Split(',');

            // Act
            bool res = txt.ContainsAll(args);

            // Assert
            Assert.AreEqual(true, res);
        }
    }
}
