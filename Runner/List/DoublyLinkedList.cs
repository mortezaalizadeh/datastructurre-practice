using System;
using System.Collections;
using System.Collections.Generic;

namespace Runner.List
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

    public class DoublyLinkedList<T> : System.Collections.Generic.ICollection<T> where T : IComparable<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }

        public void AddHead(T item)
        {
            if (Head == null && Tail == null)
            {
                Head = new DoublyLinkedListNode<T>(item);
                Tail = Head;
            }
            else if (Head != null)
            {
                Head.Prev = new DoublyLinkedListNode<T>(item) {Next = Head};
                Head = Head.Prev;
            }
        }

        public void AddTail(T item)
        {
            if (Head == null && Tail == null)
            {
                Head = new DoublyLinkedListNode<T>(item);
                Tail = Head;
            }
            else if (Tail != null)
            {
                Tail.Next = new DoublyLinkedListNode<T>(item) {Prev = Tail};
                Tail = Tail.Next;
            }
        }

        public bool RemoveHead()
        {
            if (Head == null)
            {
                return false;
            }
            else
            {
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                    Head.Prev = null;
                    if (Head == null)
                    {
                        Tail = null;
                    }
                }

                return true;
            }
        }

        public bool RemoveTail()
        {
            if (Tail == null)
            {
                return false;
            }
            else
            {
                if (Head == Tail)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail = Tail.Prev;
                    Tail.Next = null;

                    if (Tail == null)
                    {
                        Head = null;
                    }
                }

                return true;
            }
        }

        public void Add(T item)
        {
            AddTail(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public DoublyLinkedListNode<T> Find(T item)
        {
            var current = Head;

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
            var current = Head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = Head;
            var prev = current;
            var removed = false;

            do
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (Head == current)
                    {
                        Head = Head.Next;
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

            if (Head == null)
            {
                Tail = null;
            }

            return removed;
        }

        public int Count
        {
            get
            {
                var current = Head;
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
            var current = Head;

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
    }
}