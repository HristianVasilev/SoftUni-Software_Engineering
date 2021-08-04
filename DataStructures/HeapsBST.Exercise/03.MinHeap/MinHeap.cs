namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            T element = this.Peek();

            Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            HeapifyDown();

            return element;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            HeapifyUp(this.Size - 1);
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return this.elements[0];
        }


        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = GetParentIndex(index);

            SwapIfSmaller(index, parentIndex);

            index = parentIndex;
            HeapifyUp(index);
        }
        private void HeapifyDown(int index = 0)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (!ValidIndex(leftChildIndex))
            {
                return;
            }

            int secondIndex;

            if (!ValidIndex(rightChildIndex))
            {
                secondIndex = leftChildIndex;
            }
            else if (this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) < 0)
            {
                secondIndex = leftChildIndex;
            }
            else
            {
                secondIndex = rightChildIndex;
            }

            SwapIfSmaller(secondIndex, index);
            index = secondIndex;
            HeapifyDown(index);
        }


        private void Swap(int index1, int index2)
        {
            var temp = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = temp;
        }
        private void SwapIfSmaller(int index1, int index2)
        {
            if (this.elements[index1].CompareTo(this.elements[index2]) < 0)
            {
                Swap(index1, index2);
            }
        }


        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }


        private bool ValidIndex(int leftChildIndex)
        {
            return leftChildIndex >= 0 && leftChildIndex < this.elements.Count;
        }
        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("The heap is empty!");
            }
        }
    }
}
