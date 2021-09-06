using System;
using System.Collections.Generic;
using System.Text;

namespace _02.LegionSystem.Models
{
    public class PriorityQueue<T> where T : IComparable
    {
        private List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.Size - 1);
        }

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

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Empty heap!");
            }

            return this.elements[0];
        }

        public void Remove(T element)
        {
            this.elements.Remove(element);
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = GetParentIndex(index);

            T element = this.elements[index];
            T parent = this.elements[parentIndex];

            if (element.CompareTo(parent) > 0)
            {
                Swap(index, parentIndex);
            }

            index = parentIndex;
            HeapifyUp(index);
        }

        private void HeapifyDown(int index)
        {
            if (index == this.Size - 1)
            {
                return;
            }

            int leftChildIndex = 2 * index + 1;

            if (!ValidIndex(leftChildIndex))
            {
                return;
            }

            int rightChildIndex = 2 * index + 2;
            int greaterChildIndex = GetGreaterChildIndex(leftChildIndex, rightChildIndex);

            T parent = this.elements[index];
            T greaterChild = this.elements[greaterChildIndex];

            if (greaterChild.CompareTo(parent) > 0)
            {
                Swap(index, greaterChildIndex);
            }

            HeapifyDown(index + 1);
        }

        private int GetGreaterChildIndex(int leftChildIndex, int rightChildIndex)
        {
            int greaterChildIndex;
            if (!ValidIndex(rightChildIndex))
            {
                greaterChildIndex = leftChildIndex;
            }
            else
            {
                if (this.elements[leftChildIndex].CompareTo(this.elements[rightChildIndex]) > 0)
                {
                    greaterChildIndex = leftChildIndex;
                }
                else
                {
                    greaterChildIndex = rightChildIndex;
                }
            }

            return greaterChildIndex;
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

        private bool ValidIndex(int index)
        {
            return index >= 0 && index < this.Size;
        }
    }
}
