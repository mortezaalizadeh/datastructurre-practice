using System;
using System.Linq;

namespace Runner
{
    public static class Program
    {
        private static void Main()
        {
            TestDoublyLinkList();
            TestQueue();
            TestStack();
        }

        private static void TestDoublyLinkList()
        {
            var list = new DoublyLinkedList<int>();

            list.Add(10);
            list.Add(2);
            list.Add(4);
            list.Add(9);
            list.Add(20);
            list.Add(16);

            Console.WriteLine(list);
            
            list.InsertBefore(null, 4);
            Console.WriteLine(list);

            list.AddHead(10);
            list.AddHead(20);
            
            list.InsertBefore(list.Find(10), 5);
            Console.WriteLine(list);

            list.InsertBefore(list.Find(4), 6);
            Console.WriteLine(list);

            list.AddHead(30);

            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            list.Find(10);
            list.Find(100);

            list.Contains(10);
            list.Contains(100);
        }

        private static void TestQueue()
        {
            var queue = new Queue<int>();
            var item = 0;
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(4);

            Console.WriteLine(queue.Dequeue(ref item));
            Console.WriteLine(item);
            
            Console.WriteLine(queue.Dequeue(ref item));
            Console.WriteLine(item);

            queue.Enqueue(5);
            queue.Enqueue(3);
            
            Console.WriteLine(queue);
        }

        private static void TestStack()
        {
            var stack = new Stack<int>();
            var item = 0;
            
            stack.Push(1);
            stack.Push(2);
            stack.Push(4);

            Console.WriteLine(stack.Pop(ref item));
            Console.WriteLine(item);
            
            Console.WriteLine(stack.Pop(ref item));
            Console.WriteLine(item);

            stack.Push(5);
            stack.Push(3);
            
            Console.WriteLine(stack);
       }
    }
}