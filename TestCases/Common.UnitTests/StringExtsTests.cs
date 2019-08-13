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
                Assert.IsTrue(res.EndsWith(trail));
            }
            else
            {
                Assert.AreEqual(text, res);
                Assert.IsFalse(res.EndsWith(trail));
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
                Assert.IsTrue(res.EndsWith(trail));
            }
            else
            {
                Assert.AreEqual(text, res);
            }
        }

        [Theory]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("https://ionicons.com/")]
        [TestCase("https://radioapp.tk/stations/1/classic-105")]
        [TestCase("'Cyrillic' is not a supported encoding name.")]
        public void Url_Slugify(string txt)
        {
            // Arrange
            bool isSlug = txt.IsValidUrlSlug();
            // Act
            string slug = txt.GenerateUrlSlug();
            // Assert
            Log(slug);
            if (txt.IsValid())
            {
                Assert.IsTrue(slug.IsValidUrlSlug());
                Assert.IsFalse(isSlug);
            }
            else
            {
                Assert.AreEqual(txt, slug);
            }
        }
    }
}