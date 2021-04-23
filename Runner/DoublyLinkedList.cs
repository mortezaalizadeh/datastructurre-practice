using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Runner
{
    public class DoublyLinkedListNode<T> where T : IComparable<T>
    {
        public T Value { get; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList<T> : ICollection<T> where T : IComparable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;

        public void AddHead(T item)
        {
            if (_head == null && _tail == null)
            {
                _head = new DoublyLinkedListNode<T>(item);
                _tail = _head;
            }
            else if (_head != null)
            {
                _head.Prev = new DoublyLinkedListNode<T>(item) {Next = _head};
                _head = _head.Prev;
            }
        }

        public void AddTail(T item)
        {
            if (_head == null && _tail == null)
            {
                _head = new DoublyLinkedListNode<T>(item);
                _tail = _head;
            }
            else if (_tail != null)
            {
                _tail.Next = new DoublyLinkedListNode<T>(item) {Prev = _tail};
                _tail = _tail.Next;
            }
        }

        public bool RemoveHead()
        {
            if (_head == null)
            {
                return false;
            }
            else
            {
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next;
                    _head.Prev = null;
                    if (_head == null)
                    {
                        _tail = null;
                    }
                }

                return true;
            }
        }

        public bool RemoveTail()
        {
            if (_tail == null)
            {
                return false;
            }
            else
            {
                if (_head == _tail)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _tail = _tail.Prev;
                    _tail.Next = null;

                    if (_tail == null)
                    {
                        _head = null;
                    }
                }

                return true;
            }
        }

        public void Add(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) > 0)
                {
                    InsertBefore(current, item);

                    return;
                }

                current = current.Next;
            }

            AddTail(item);
        }

        public bool PeekHead(ref T item)
        {
            if (_head == null)
            {
                return false;
            }

            item = _head.Value;

            return true;
        }

        public bool PeekTail(ref T item)
        {
            if (_tail == null)
            {
                return false;
            }

            item = _tail.Value;

            return true;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
        }

        public DoublyLinkedListNode<T> Find(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public bool Contains(T item) => Find(item) != null;

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = _head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = _head;
            var prev = current;
            var removed = false;

            do
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (_head == current)
                    {
                        _head = _head.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }

                    removed = true;
                }

                prev = current;
                current = current.Next;
            } while (current != null);

            if (_head == null)
            {
                _tail = null;
            }

            return removed;
        }

        public int Count
        {
            get
            {
                var current = _head;
                var count = 0;

                while (current != null)
                {
                    current = current.Next;
                    count++;
                }

                return count;
            }
        }

        public bool IsReadOnly { get; } = false;

        public void InsertAfter(DoublyLinkedListNode<T> node, T item)
        {
            if (node == null)
            {
                AddTail(item);

                return;
            }

            var current = _head;

            while (current != null)
            {
                if (current == node)
                {
                    var newNode = new DoublyLinkedListNode<T>(item) {Next = current.Next, Prev = current};

                    if (current.Next == null)
                    {
                        _tail = newNode;
                    }
                    else
                    {
                        current.Next.Prev = newNode;
                    }

                    current.Next = newNode;

                    break;
                }

                current = current.Next;
            }
        }

        public void InsertBefore(DoublyLinkedListNode<T> node, T item)
        {
            if (node == null)
            {
                AddHead(item);

                return;
            }

            var current = _head;

            while (current != null)
            {
                if (current == node)
                {
                    var newNode = new DoublyLinkedListNode<T>(item) {Next = current, Prev = current.Prev};

                    if (current.Prev == null)
                    {
                        _head = newNode;
                    }
                    else
                    {
                        current.Prev.Next = newNode;
                    }

                    current.Prev = newNode;

                    break;
                }

                current = current.Next;
            }
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() =>
            this.Aggregate(
                    string.Empty,
                    (reduction, value) => $"{reduction}, {value.ToString()}")
                .Trim(',')
                .Trim();
    }
}