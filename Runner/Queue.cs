using System;
using System.Collections;
using System.Collections.Generic;

namespace Runner
{
    public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly DoublyLinkedList<T> _store = new DoublyLinkedList<T>();

        public void Enqueue(T item) => _store.AddTail(item);

        public bool Dequeue(ref T item) => _store.PeekHead(ref item) && _store.RemoveHead();

        public IEnumerator<T> GetEnumerator() => _store.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => _store.ToString();
    }
}