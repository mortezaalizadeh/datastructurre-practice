using System;
using System.Collections;
using System.Collections.Generic;

namespace Runner.List
{
    public class LinkedList<T>  where T : IComparable<T>
    {
        internal class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node _head = null;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new Node
                {
                    Value = value,
                    Next = null,
                };
            }
            else
            {
                var current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = new Node()
                {
                    Value = value,
                    Next = null,
                };
            }
        }

        public void Remove(T value)
        {
            var current = _head;
            var prev = current;

            do
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    if (_head == current)
                    {
                        _head = _head.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                }

                prev = current;
                current = current.Next;
            } while (current != null);
        }

        public int Count()
        {
            var current = _head;
            int count = 0;

            while (current != null)
            {
                current = current.Next;
                count++;
            }

            return count;
        }
    }
}