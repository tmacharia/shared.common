using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Common.UnitTests
{
    public class CollectionExtsTests : TestData
    {
        private readonly IEnumerable<int> list;
        public CollectionExtsTests()
        {
            list = Enumerable.Range(10, 50);
        }
        [Order(1)]
        [TestCase(Category = COLLECTION_TESTS)]
        public void ForEach_Enumerator()
        {
            int n = 0;
            list.ForEach((index, num) =>
            {
                Log("{0:N0}. {1:N0}", index, num);
                Assert.Equals(n, index);
                n++;
            });
        }
        [Order(0)]
        [TestCase(Category = COLLECTION_TESTS)]
        public void Contains_Predicate()
        {
            bool b = list.Contains(x => x == 45);
            Assert.Equals(true, b);

            b = list.Contains(x => x == 65);
            Assert.Equals(false, b);
        }
    }
}