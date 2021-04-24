using System;
using System.Linq;
using DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureUnitTests
{
    [TestClass]
    public class SortTests
    {
        private readonly Random _random = new();

        [TestMethod]
        public void BubbleSortTest()
        {
            var data = Enumerable.Range(10, _random.Next(500, 10000)).Select(i => _random.Next(1, 10000)).ToArray();
            var expected = data.OrderBy(i => i).ToArray();

            data = new BubbleSort<int>().Sort(data);

            for (var i = 0; i < data.Length; i++) Assert.IsTrue(data[i] == expected[i]);
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            var data = Enumerable.Range(10, _random.Next(500, 10000)).Select(i => _random.Next(1, 10000)).ToArray();
            var expected = data.OrderBy(i => i).ToArray();

            data = new InsertionSort<int>().Sort(data);

            for (var i = 0; i < data.Length; i++) Assert.IsTrue(data[i] == expected[i]);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            var data = Enumerable.Range(10, _random.Next(500, 10000)).Select(i => _random.Next(1, 10000)).ToArray();
            var expected = data.OrderBy(i => i).ToArray();

            data = new MergeSort<int>().Sort(data);

            for (var i = 0; i < data.Length; i++) Assert.IsTrue(data[i] == expected[i]);
        }
    }
}