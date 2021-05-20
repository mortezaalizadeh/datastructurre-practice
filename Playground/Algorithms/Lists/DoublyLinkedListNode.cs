using System;

namespace Algorithms.Lists
{
    public class DoublyLinkedListNode<T> where T : IComparable<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
    }
}