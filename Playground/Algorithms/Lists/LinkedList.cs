using System;
using System.Collections;
using System.Collections.Generic;

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

    public class LinkedList<T> : ICollection<T> where T : IComparable<T>
    {
        private LinkedListNode<T> _head;

        public LinkedList()
        {
            _head = null;
        }

        public LinkedList(IEnumerable<T> items)
        {
            _head = null;

            foreach (var item in items) Add(item);
        }

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new LinkedListNode<T>(item);
            }
            else
            {
                var current = _head;

                while (current.Next != null) current = current.Next;

                current.Next = new LinkedListNode<T>(item);
                current.Next.Next = null;
            }

            Count++;
        }


        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0) return true;

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = _head;

            while (current != null && array.Length > arrayIndex)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = _head;
            LinkedListNode<T> prev = null;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (current == _head)
                        _head = _head.Next;
                    else
                        prev.Next = current.Next;

                    Count--;

                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddHead(T item)
        {
            var node = new LinkedListNode<T>(item)
            {
                Next = _head
            };

            _head = node;

            Count++;
        }

        public bool InsertBefore(T item, T value)
        {
            var current = _head;
            LinkedListNode<T> prev = null;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (current == _head)
                    {
                        AddHead(value);
                    }
                    else
                    {
                        var node = new LinkedListNode<T>(value)
                        {
                            Next = current
                        };

                        prev.Next = node;
                        Count++;
                    }

                    return true;
                }

                prev = current;
                current = current.Next;
            }

            return false;
        }

        public bool InsertAfter(T item, T value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    var node = new LinkedListNode<T>(value)
                    {
                        Next = current.Next
                    };

                    current.Next = node;
                    Count++;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }
    }
}