using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class DoublyLinkedListNode<T> where T : IComparable<T>
    {
        public DoublyLinkedListNode(T item)
        {
            Item = item;
        }

        public T Item { get; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }
    }

    public class DoublyLinkedList<T> : ICollection<T> where T : IComparable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;

        public void Add(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Item.CompareTo(item) > 0)
                {
                    InsertBefore(current, item);

                    return;
                }

                current = current.Next;
            }

            AddTail(item);
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = _head;

            while (current != null)
            {
                array[arrayIndex++] = current.Item;
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
                if (current.Item.CompareTo(item) == 0)
                {
                    if (_head == current)
                        _head = _head.Next;
                    else
                        prev.Next = current.Next;

                    removed = true;
                }

                prev = current;
                current = current.Next;
            } while (current != null);

            if (_head == null) _tail = null;

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

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Item;
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
            if (_head == null) return false;

            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _head = _head.Next;
                _head.Prev = null;
                if (_head == null) _tail = null;
            }

            return true;
        }

        public bool RemoveTail()
        {
            if (_tail == null) return false;

            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail = _tail.Prev;
                _tail.Next = null;

                if (_tail == null) _head = null;
            }

            return true;
        }

        public bool PeekHead(ref T item)
        {
            if (_head == null) return false;

            item = _head.Item;

            return true;
        }

        public bool PeekTail(ref T item)
        {
            if (_tail == null) return false;

            item = _tail.Item;

            return true;
        }

        public DoublyLinkedListNode<T> Find(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Item.CompareTo(item) == 0) return current;

                current = current.Next;
            }

            return null;
        }

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
                        _tail = newNode;
                    else
                        current.Next.Prev = newNode;

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
                        _head = newNode;
                    else
                        current.Prev.Next = newNode;

                    current.Prev = newNode;

                    break;
                }

                current = current.Next;
            }
        }

        public override string ToString()
        {
            return this.Aggregate(
                    string.Empty,
                    (reduction, item) => $"{reduction}, {item.ToString()}")
                .Trim(',')
                .Trim();
        }
    }
}