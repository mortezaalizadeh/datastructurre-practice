using System;

namespace DataStructure.Sort
{
    public class InsertionSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override T[] Sort(T[] data)
        {
            for (var i = 1; i < data.Length; i++)
            {
                if (data[i - 1].CompareTo(data[i]) <= 0) continue;

                for (var j = i; j > 0; j--)
                {
                    if (data[j].CompareTo(data[j - 1]) >= 0) break;

                    Swap(data, j, j - 1);
                }
            }

            return data;
        }
    }
}