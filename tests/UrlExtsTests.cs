using System.Extensions;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class UrlExtsTests : TestData
    {
        [Theory]
        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("https://ionicons.com/", true)]
        [TestCase("https://radioapp.tk/stations/1/classic-105", true)]
        [TestCase("'Cyrillic' is not a supported encoding name.", true)]
        public void Slugify(string txt, bool isValidSlug)
        {
            // Act
            string slug = txt.Sluggify();
            // Assert
            Log(slug);
            if (txt.IsValid())
            {
                Assert.AreEqual(isValidSlug, slug.IsValidUrlSlug());
            }
            else
            {
                Assert.AreEqual(txt, slug);
            }
        }
    }
}
