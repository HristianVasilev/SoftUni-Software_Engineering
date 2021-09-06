namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Item = item,
            };

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head.Previous = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Item = item,
            };

            if (this.Count == 0)
            {
                newNode.Next = tail;
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Previous = this.tail;
                this.tail.Next = newNode;

                this.tail = newNode;
            }

            this.Count++;
        }


        public T GetFirst()
        {
            EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return this.tail.Item;
        }


        public T RemoveFirst()
        {
            EnsureNotEmpty();

            T element = this.GetFirst();
            this.head = this.head.Next;
            this.Count--;

            return element;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            T element = this.GetLast();
            this.tail = this.tail.Previous;
            this.Count--;

            return element;
        }


        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = this.head;

            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }
        }
    }
}