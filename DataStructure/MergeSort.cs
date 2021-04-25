using System;
using System.Collections.Generic;

namespace DataStructure
{
    public class MergeSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override T[] Sort(T[] data)
        {
            if (data.Length <= 1) return data;

            var leftSize = data.Length / 2;
            var rightSize = data.Length - leftSize;

            var left = new T[leftSize];
            var right = new T[rightSize];

            Array.Copy(data, 0, left, 0, leftSize);
            Array.Copy(data, leftSize, right, 0, rightSize);

            Sort(left);
            Sort(right);

            return Merge(data, left, right);
        }

        private static T[] Merge(T[] data, IReadOnlyList<T> left, IReadOnlyList<T> right)
        {
            var leftIdx = 0;
            var rightIdx = 0;
            var dataIdx = 0;

            while (dataIdx < data.Length)
                if (leftIdx < left.Count && rightIdx < right.Count)
                {
                    if (left[leftIdx].CompareTo(right[rightIdx]) < 0)
                        data[dataIdx++] = left[leftIdx++];
                    else
                        data[dataIdx++] = right[rightIdx++];
                }
                else if (leftIdx < left.Count)
                {
                    data[dataIdx++] = left[leftIdx++];
                }
                else
                {
                    data[dataIdx++] = right[rightIdx++];
                }

            return data;
        }
    }
}