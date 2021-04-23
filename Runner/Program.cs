using System;
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

            list.AddHead(10);
            list.AddHead(20);
            list.AddHead(30);

            list.AddTail(1);
            list.AddTail(2);
            list.AddTail(3);

            list.Find(10);
            list.Find(100);

            list.Contains(10);
            list.Contains(100);

            Console.WriteLine(
                list.Aggregate(
                        string.Empty,
                        (reduction, value) => $"{reduction}, {value.ToString()}")
                    .Trim(','));
        }
    }
}