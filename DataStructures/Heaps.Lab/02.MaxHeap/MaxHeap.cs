namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size { get { return this.elements.Count; } }

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(Size - 1);
        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Empty heap!");
            }

            return this.elements[0];
        }


        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = this.GetParentIndex(index);

            if (this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
            }

            index = parentIndex;
            HeapifyUp(index);
        }
        private void Swap(int index, int parentIndex)
        {
            T temp = this.elements[index];
            this.elements[parentIndex] = temp;
            this.elements[index] = this.elements[parentIndex];
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
