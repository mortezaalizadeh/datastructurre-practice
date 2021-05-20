using System;
using System.Collections.Generic;
using System.Linq;

using Algorithms.Tree;

using Xunit;

namespace Algorithms.UnitTests.TreeTests
{
    public class BinaryTreeTests
    {
        private readonly IReadOnlyList<int> _prePopulatedRandomList;
        private readonly Random _random = new();

        public BinaryTreeTests()
        {
            _prePopulatedRandomList = Enumerable.Range(0, _random.Next(100, 1000))
                .Select(i => _random.Next(0, 1000000))
                .ToList();
        }

        [Fact]
        public void Count_Should_Return_Zero_On_Empty_Tree()
        {
            var tree = new BinaryTree<int>();

            Assert.Equal(0, tree.Count);
            Assert.Empty(tree);
        }

        [Fact]
        public void Count_Should_Return_One_On_Tree_With_Root_Item_Only()
        {
            var tree = new BinaryTree<int> { 1 };

            Assert.Equal(1, tree.Count);
            Assert.Single(tree);
        }

        [Fact]
        public void Add_Should_Work_On_Empty_Tree()
        {
            var tree = new BinaryTree<int>();

            tree.Add(1);

            Assert.Equal(1, tree.Count);
            Assert.Single(tree);
        }

        [Fact]
        public void Add_Should_Add_Item_To_Right_Branch_If_Item_IsGreaterThan_Root_Node()
        {
            var itemsToAdd = new List<int> { 2, 3 };
            var tree = new BinaryTree<int>();

            itemsToAdd.ForEach(tree.Add);
            itemsToAdd.Sort();

            Assert.Equal(itemsToAdd.Count, tree.Count);
            Assert.True(itemsToAdd.SequenceEqual(tree.InOrderTraversal()));
        }

        [Fact]
        public void Add_Should_Add_Item_To_Left_Branch_If_Item_IsSmallerThan_Root_Node()
        {
            var itemsToAdd = new List<int> { 2, 1 };
            var tree = new BinaryTree<int>();

            itemsToAdd.ForEach(tree.Add);
            itemsToAdd.Sort();

            Assert.Equal(itemsToAdd.Count, tree.Count);
            Assert.True(itemsToAdd.SequenceEqual(tree.InOrderTraversal()));
        }

        [Fact]
        public void Add_Should_Add_Item_To_Correct_Order()
        {
            //          10
            //      5       11
            //     4  9
            //    3  7
            //        8

            var itemsToAdd = new List<int> { 10, 5, 4, 9, 7, 8, 3, 11 };
            var tree = new BinaryTree<int>();

            itemsToAdd.ForEach(tree.Add);
            itemsToAdd.Sort();

            Assert.Equal(itemsToAdd.Count, tree.Count);
            Assert.True(itemsToAdd.SequenceEqual(tree.InOrderTraversal()));
        }

        [Fact]
        public void Contains_Should_Return_False_On_Empty_Tree()
        {
            var tree = new BinaryTree<int>();

            Assert.False(tree.Contains(1));
        }

        [Fact]
        public void Contains_Should_Work_On_Tree_With_Root_Item_Only()
        {
            var tree = new BinaryTree<int> { 1 };

            Assert.True(tree.Contains(1));
            Assert.False(tree.Contains(10));
        }

        [Fact]
        public void Contains_Should_Work_On_Large_Tree()
        {
            var tree = new BinaryTree<int>(_prePopulatedRandomList);

            Assert.True(tree.Contains(
                _prePopulatedRandomList[_random.Next(0, _prePopulatedRandomList.Count - 1)]));
        }

        [Fact]
        public void Find_Should_Return_False_On_Empty_Tree()
        {
            var tree = new BinaryTree<int>();

            Assert.Null(tree.Find(1));
        }

        [Fact]
        public void Find_Should_Work_On_Tree_With_Root_Item_Only()
        {
            var tree = new BinaryTree<int> { 1 };

            Assert.NotNull(tree.Find(1));
            Assert.Null(tree.Find(10));
        }

        [Fact]
        public void Find_Should_Work_On_Large_Tree()
        {
            var tree = new BinaryTree<int>(_prePopulatedRandomList);

            Assert.NotNull(tree.Find(
                _prePopulatedRandomList[_random.Next(0, _prePopulatedRandomList.Count - 1)]));
        }
    }
}