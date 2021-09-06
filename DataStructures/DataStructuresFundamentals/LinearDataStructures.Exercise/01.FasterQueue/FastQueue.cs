namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> node = this.head;

            while (node != null)
            {
                T element = node.Item;

                if (element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            T element = this.head.Item;
            this.head = this.head.Next;
            this.Count--;

            return element;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = this.tail.Next;
            }

            this.Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}