using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Lists
{
    public class DoublyLinkedList<T> : ICollection<T> where T : IComparable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;

        public DoublyLinkedList()
        {
        }

        public DoublyLinkedList(IEnumerable<T> items)
        {
            foreach (var item in items)
                AddTail(item);
        }

        public void Add(T item)
        {
            AddTail(item);
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
                if (current.Value.CompareTo(item) == 0)
                    return true;

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

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (current == _head)
                    {
                        _head = _head.Next;
                        _head.Prev = null;
                    }
                    else
                    {
                        if (current.Next == null)
                        {
                            current.Prev.Next = null;
                        }
                        else
                        {
                            current.Prev.Next = current.Next;
                            current.Next.Prev = current.Prev;
                        }
                    }

                    Count--;

                    return true;
                }

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
            if (_head == null && _tail == null)
            {
                _head = _tail = new DoublyLinkedListNode<T>(item);
            }
            else if (_head != null)
            {
                _head.Prev = new DoublyLinkedListNode<T>(item) { Next = _head };
                _head = _head.Prev;
            }

            Count++;
        }

        public void AddTail(T item)
        {
            if (_head == null && _tail == null)
            {
                _head = _tail = new DoublyLinkedListNode<T>(item);
            }
            else if (_tail != null)
            {
                _tail.Next = new DoublyLinkedListNode<T>(item) { Prev = _tail };
                _tail = _tail.Next;
            }

            Count++;
        }

        public bool InsertBefore(T item, T value)
        {
            var current = _head;

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
                        var node = new DoublyLinkedListNode<T>(value)
                        {
                            Next = current,
                            Prev = current.Prev
                        };

                        if (current.Prev == null)
                            _head = node;
                        else
                            current.Prev.Next = node;

                        current.Prev = node;

                        Count++;
                    }

                    return true;
                }

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
                    var node = new DoublyLinkedListNode<T>(value)
                    {
                        Next = current.Next,
                        Prev = current
                    };

                    if (current.Next == null)
                        _tail = node;
                    else
                        current.Next.Prev = node;

                    current.Next = node;

                    Count++;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public IEnumerable<T> GetReverseEnumerator()
        {
            var current = _tail;

            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        public bool PeekHead(out T value)
        {
            if (_head == null)
            {
                value = default;

                return false;
            }

            value = _head.Value;

            return true;
        }

        public bool PeekTail(out T value)
        {
            if (_tail == null)
            {
                value = default;

                return false;
            }

            value = _tail.Value;

            return true;
        }

        public bool PopHead(out T value)
        {
            if (_head == null)
            {
                value = default;

                return false;
            }

            value = _head.Value;
            RemoveHead();

            return true;
        }

        public bool PopTail(out T value)
        {
            if (_tail == null)
            {
                value = default;

                return false;
            }

            value = _tail.Value;
            RemoveTail();

            return true;
        }

        public void RemoveHead()
        {
            if (_head == null)
                return;

            _head = _head.Next;

            if (_head == null)
                _tail = null;
            else
                _head.Prev = null;

            Count--;
        }

        public void RemoveTail()
        {
            if (_tail == null)
                return;

            _tail = _tail.Prev;

            if (_tail == null)
                _head = null;
            else
                _tail.Next = null;

            Count--;
        }
    }
}