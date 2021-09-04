using System.Collections.Generic;
using NUnit.Framework;

namespace Common.UnitTests
{
    public class BackpackTests
    {
        [Test]
        [Ignore("Obsolete")]
        public void PredictFileName_Returns_ClassName()
        {
            // Arrange
            string ans = "backpacktests";
            // Act
            string n1 = Backpack.PredictFileName<BackpackTests>();
            string n2 = Backpack.PredictFileName<List<BackpackTests>>();
            string n3 = Backpack.PredictFileName<IList<BackpackTests>>();
            string n4 = Backpack.PredictFileName<IEnumerable<BackpackTests>>();
            // Assert
            Assert.AreEqual(ans, n1);
            Assert.AreEqual(ans, n2);
            Assert.AreEqual(ans, n3);
            Assert.AreEqual(ans, n4);
        }
    }
}