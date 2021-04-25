using System;
using System.Linq;
using DataStructure.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureUnitTests
{
    [TestClass]
    public class SortTests
    {
        private static readonly Random _random = new();
        private readonly int[] _expected;

        private int[] _data = Enumerable.Range(10, new Random().Next(500, 10000)).Select(i => _random.Next(1, 10000))
            .ToArray();

        public SortTests()
        {
            _expected = _data.OrderBy(i => i).ToArray();
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            _data = new BubbleSort<int>().Sort(_data);

            for (var i = 0; i < _data.Length; i++) Assert.IsTrue(_data[i] == _expected[i]);
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            _data = new InsertionSort<int>().Sort(_data);

            for (var i = 0; i < _data.Length; i++) Assert.IsTrue(_data[i] == _expected[i]);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            _data = new MergeSort<int>().Sort(_data);

            for (var i = 0; i < _data.Length; i++) Assert.IsTrue(_data[i] == _expected[i]);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            _data = new QuickSort<int>().Sort(_data);

            for (var i = 0; i < _data.Length; i++) Assert.IsTrue(_data[i] == _expected[i]);
        }
    }
}