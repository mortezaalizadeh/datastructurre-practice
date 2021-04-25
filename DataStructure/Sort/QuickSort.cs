using System;

namespace DataStructure.Sort
{
    public class QuickSort<T> : SortBase<T> where T : IComparable<T>
    {
        private readonly Random _random = new();

        public override T[] Sort(T[] data)
        {
            Sort(data, 0, data.Length - 1);

            return data;
        }

        private void Sort(T[] data, int left, int right)
        {
            if (left >= right) return;

            var pivotIndex = _random.Next(left, right);
            var newPivot = Partition(data, left, right, pivotIndex);

            Sort(data, left, newPivot - 1);
            Sort(data, newPivot + 1, right);
        }

        private int Partition(T[] data, int left, int right, int pivotIndex)
        {
            var pivotValue = data[pivotIndex];

            Swap(data, pivotIndex, right);

            var storeIndex = left;

            for (var i = left; i < right; i++)
            {
                if (data[i].CompareTo(pivotValue) >= 0) continue;

                Swap(data, i, storeIndex);
                storeIndex += 1;
            }

            Swap(data, storeIndex, right);

            return storeIndex;
        }
    }
}