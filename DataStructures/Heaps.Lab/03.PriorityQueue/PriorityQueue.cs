namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Empty heap!");
            }

            T element = this.elements[0];

            Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);
            HeapifyDown(0);

            return element;
        }



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
        private void Swap(int index1, int index2)
        {
            T temp = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = temp;
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void HeapifyDown(int index)
        {
            if (index == this.Size - 1)
            {
                return;
            }

            int leftChildIndex = 2 * index + 1;
            if (leftChildIndex > this.Size - 1)
            {
                return;
            }

            int rightChildIndex = 2 * index + 2;

            T current = this.elements[index];
            T leftChild = this.elements[leftChildIndex];

            if (rightChildIndex > this.Size - 1)
            {
                if (leftChild.CompareTo(current) > 0)
                {
                    Swap(index, leftChildIndex);
                    index = leftChildIndex;
                    HeapifyDown(index);
                }

                return;
            }

            T rightChild = this.elements[rightChildIndex];

            if (leftChild.CompareTo(rightChild) > 0 && leftChild.CompareTo(current) > 0)
            {
                Swap(index, leftChildIndex);
                index = leftChildIndex;
                HeapifyDown(index);
            }
            else if (rightChild.CompareTo(leftChild) > 0 && rightChild.CompareTo(current) > 0)
            {
                Swap(index, rightChildIndex);
                index = rightChildIndex;
                HeapifyDown(index);
            }
        }
    }
}
