using System;
using System.Collections.Generic;

namespace DataStructure.StringExtensions
{
    public class BoyerMooreHorspool
    {
        public IEnumerable<int> Search(string str, string pattern)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            if (pattern == null) throw new ArgumentNullException(nameof(pattern));

            if (str.Length <= 0 || pattern.Length <= 0) yield break;

            var badMatchTable = new BadMatchTable(pattern);
            var currentStartIdx = 0;

            while (currentStartIdx < str.Length - pattern.Length)
            {
                var charactersLeftToMatch = pattern.Length - 1;

                while (charactersLeftToMatch >= 0 &&
                       pattern[charactersLeftToMatch] == str[currentStartIdx + charactersLeftToMatch])
                    charactersLeftToMatch--;

                if (charactersLeftToMatch < 0)
                {
                    yield return currentStartIdx;
                    currentStartIdx += pattern.Length;
                }
                else
                {
                    currentStartIdx += badMatchTable[str[currentStartIdx + pattern.Length - 1]];
                }
            }
        }
    }
}