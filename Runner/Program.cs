﻿using System;
using System.Linq;
using Runner.List;

namespace Runner
{
    public static class Program
    {
        private static void Main()
        {
            TestDoublyLinkList();
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
    }
}