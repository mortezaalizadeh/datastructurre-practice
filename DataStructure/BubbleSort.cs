using System;

namespace DataStructure
{
    public class BubbleSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override T[] Sort(T[] data)
        {
            for (var i = 0; i < data.Length - 1; i++)
            {
                var again = false;
                for (var j = i + 1; j < data.Length; j++)
                {
                    if (data[i].CompareTo(data[j]) <= 0) continue;

                    Swap(data, i, j);
                    again = true;
                }

                if (!again) break;
            }

            return data;
        }
    }
}