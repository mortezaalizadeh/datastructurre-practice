using System;
using DataStructure.StringExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructureUnitTests.StringExtensionsTests
{
    [TestClass]
    public class BoyerMooreHorspoolTests
    {
        private readonly BoyerMooreHorspool _boyerMooreHorspool = new();

        [TestMethod]
        public void Test1()
        {
            const string str = "This is a string test string tes";
            const string pattern = "string";

            foreach (var idx in _boyerMooreHorspool.Search(str, pattern))
                Console.WriteLine($"{idx.ToString()} - {str.Substring(idx, pattern.Length)}");
        }
    }
}