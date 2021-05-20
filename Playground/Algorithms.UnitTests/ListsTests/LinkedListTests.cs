using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Algorithms.UnitTests.Lists
{
    public class LinkedListTests
    {
        private readonly IReadOnlyList<int> _prePopulatedRandomList;
        private readonly Random _random = new();

        public LinkedListTests()
        {
            _prePopulatedRandomList = Enumerable.Range(0, _random.Next(100, 1000))
                .Select(i => _random.Next(0, 1000000))
                .ToList();
        }

        [Fact]
        public void Empty_List_Count_Should_Be_Zero()
        {
            Assert.Empty(new Algorithms.Lists.LinkedList<int>());
        }

        [Fact]
        public void Add_Should_Add_Item_To_EmptyList()
        {
            var list = new Algorithms.Lists.LinkedList<int>();

            list.Add(10);

            Assert.Single(list);
        }

        [Fact]
        public void Add_Should_Add_Item_To_Non_EmptyList()
        {
            var list = new Algorithms.Lists.LinkedList<int>();

            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void Add_Should_Increment_Count()
        {
            var list = new Algorithms.Lists.LinkedList<int>();

            list.Add(10);
            list.Add(20);

            Assert.Equal(2, list.Count);
            list.Add(30);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void Constructor_Should_Keep_Added_Order()
        {
            var list = new Algorithms.Lists.LinkedList<int>(_prePopulatedRandomList);

            Assert.True(_prePopulatedRandomList.SequenceEqual(list));
        }

        [Fact]
        public void Should_Keep_Added_Order()
        {
            var list = new Algorithms.Lists.LinkedList<int>();

            foreach (var item in _prePopulatedRandomList)
                list.Add(item);

            Assert.True(_prePopulatedRandomList.SequenceEqual(list));
        }

        [Fact]
        public void Should_Return_Count_Correctly()
        {
            var list = new Algorithms.Lists.LinkedList<int>(_prePopulatedRandomList);

            Assert.Equal(_prePopulatedRandomList.Count, list.Count);
        }

        [Fact]
        public void Clear_Should_Set_Count_To_Zero()
        {
            var list = new Algorithms.Lists.LinkedList<int>(_prePopulatedRandomList);

            Assert.Equal(_prePopulatedRandomList.Count, list.Count);

            list.Clear();

            Assert.Empty(list);
        }

        [Fact]
        public void Contains_Should_Return_False_If_Item_Not_Exists()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.DoesNotContain(30, list);
        }

        [Fact]
        public void Contains_Should_Return_True_If_Item_Exists()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.Contains(20, list);
        }

        [Fact]
        public void Remove_Should_Return_False_If_Item_Not_Exists()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.False(list.Remove(30));
        }

        [Fact]
        public void Remove_Should_Return_True_If_Item_Exists()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.True(list.Remove(20));
        }

        [Fact]
        public void Remove_Should_Delete_Item()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.Contains(20, list);
            list.Remove(20);
            Assert.DoesNotContain(20, list);
        }

        [Fact]
        public void Remove_Should_Decrement_Count()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.Equal(2, list.Count);
            list.Remove(20);
            Assert.Single(list);
        }

        [Fact]
        public void AddHead_Should_Add_Item_To_EmptyList_Head()
        {
            var list = new Algorithms.Lists.LinkedList<int>();

            list.AddHead(10);

            Assert.Equal(10, list.First());
        }

        [Fact]
        public void AddHead_Should_Add_Item_To_NonEmptyList_Head()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10 };

            list.AddHead(20);

            Assert.Equal(20, list.First());
            Assert.Equal(10, list.Skip(1).First());
        }

        [Fact]
        public void AddHead_Should_Increment_Count()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10 };

            list.AddHead(20);

            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void InsertBefore_Should_Return_False_If_Item_NotFound()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.False(list.InsertBefore(30, 100));
        }

        [Fact]
        public void InsertBefore_Should_Return_True_If_Item_Found()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.True(list.InsertBefore(20, 100));
        }

        [Fact]
        public void InsertBefore_Should_Insert_Before_Found_Item()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10 };

            list.InsertBefore(10, 100);

            Assert.Equal(100, list.First());
            Assert.Equal(10, list.Skip(1).First());

            list.Add(20);
            list.Add(30);

            list.InsertBefore(20, 200);

            Assert.Equal(100, list.First());
            Assert.Equal(10, list.Skip(1).First());
            Assert.Equal(200, list.Skip(2).First());
            Assert.Equal(20, list.Skip(3).First());
            Assert.Equal(30, list.Last());
        }

        [Fact]
        public void InsertAfter_Should_Return_False_If_Item_NotFound()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.False(list.InsertAfter(30, 100));
        }

        [Fact]
        public void InsertAfter_Should_Return_True_If_Item_Found()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10, 20 };

            Assert.True(list.InsertAfter(20, 100));
        }

        [Fact]
        public void InsertAfter_Should_Insert_After_Found_Item()
        {
            var list = new Algorithms.Lists.LinkedList<int> { 10 };

            list.InsertAfter(10, 100);

            Assert.Equal(10, list.First());
            Assert.Equal(100, list.Skip(1).First());

            list.Add(20);
            list.Add(30);

            list.InsertAfter(20, 200);

            Assert.Equal(10, list.First());
            Assert.Equal(100, list.Skip(1).First());
            Assert.Equal(20, list.Skip(2).First());
            Assert.Equal(200, list.Skip(3).First());
            Assert.Equal(30, list.Last());
        }
    }
}