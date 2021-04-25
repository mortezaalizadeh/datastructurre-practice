using System;

namespace DataStructure.Sort
{
    public abstract class SortBase<T> : ISorting<T> where T : IComparable<T>
    {
        public abstract T[] Sort(T[] data);

        protected void Swap(T[] data, int left, int right)
        {
            if (left == right) return;

            var temp = data[left];
            data[left] = data[right];
            data[right] = temp;
        }
    }
}