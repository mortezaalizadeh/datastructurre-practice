using System.Collections.Generic;

namespace DataStructure.StringExtensions
{
    public class BadMatchTable
    {
        private readonly int _patternLength;
        private readonly Dictionary<char, int> _table = new();

        public BadMatchTable(string pattern)
        {
            _patternLength = pattern.Length;

            for (var i = 0; i < _patternLength - 1; i++) _table[pattern[i]] = _patternLength - i - 1;
        }

        public int this[char ch] => _table.TryGetValue(ch, out var idx) ? idx : _patternLength;
    }
}