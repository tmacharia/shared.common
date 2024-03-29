﻿using System.Extensions;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class UrlExtsTests : TestData
    {
        [Theory]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("https://ionicons.com/")]
        [TestCase("https://radioapp.tk/stations/1/classic-105")]
        [TestCase("'Cyrillic' is not a supported encoding name.")]
        public void Slugify(string txt)
        {
            // Arrange
            bool isSlug = txt.IsValidUrlSlug();
            // Act
            string slug = txt.Sluggify();
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