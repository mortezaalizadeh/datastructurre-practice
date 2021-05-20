using System;

namespace Algorithms.Lists
{
    public class LinkedListNode<T> where T : IComparable<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public LinkedListNode<T> Next { get; set; }
    }
}