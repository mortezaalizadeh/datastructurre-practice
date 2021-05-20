using System;
using System.Collections;
using System.Collections.Generic;

using Algorithms.Lists;

namespace Algorithms.Queue
{
    public class BasicQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly DoublyLinkedList<T> _queueStore;

        public BasicQueue()
        {
            _queueStore = new DoublyLinkedList<T>();
        }

        public BasicQueue(IEnumerable<T> items)
        {
            _queueStore = new DoublyLinkedList<T>(items);
        }

        public int Count => _queueStore.Count;

        public IEnumerator<T> GetEnumerator()
        {
            return _queueStore.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            _queueStore.AddTail(item);
        }

        public bool Pop(out T value)
        {
            return _queueStore.PopHead(out value);
        }

        public bool Peek(out T value)
        {
            return _queueStore.PeekHead(out value);
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            return _queueStore.GetReverseEnumerator();
        }
    }
}