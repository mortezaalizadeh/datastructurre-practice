using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure
{
    public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly DoublyLinkedList<T> _store = new();

        public IEnumerator<T> GetEnumerator()
        {
            return _store.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(T item)
        {
            _store.AddTail(item);
        }

        public bool Dequeue(ref T item)
        {
            return _store.PeekHead(ref item) && _store.RemoveHead();
        }

        public override string ToString()
        {
            return _store.ToString();
        }
    }
}