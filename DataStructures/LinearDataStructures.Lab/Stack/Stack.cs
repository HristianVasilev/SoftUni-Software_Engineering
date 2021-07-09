using System;
using System.Collections.Generic;

namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        class Node<E>
        {
            public Node(E item)
            {
                this.Item = item;
            }

            public E Item { get; set; }
            public Node<E> Next { get; set; }

        }

        private Node<T> top;
        private int size;

        public Stack()
        {

        }

        public Stack(ICollection<T> collection)
        {
            PushCollection(collection);
        }


        public int Count => this.size;

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;

            this.top = newNode;
            this.size++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T element = this.Peek();

            Node<T> temp = this.top.Next;

            this.top.Next = null;
            this.top = temp;
            this.size--;

            return element;
        }

        public T Peek()
        {
            return this.top.Item;
        }

        public virtual void Clear()
        {
            while (this.Count != 0)
            {
                this.Pop();
            }
        }

        public virtual Stack<T> Clone()
        {
            T[] array = this.ToArray();

            return new Stack<T>(array);
        }

        public virtual bool Contains(T item)
        {
            Node<T> currentNode = this.top;

            do
            {
                if (currentNode.Item.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            } while (currentNode != null);

            return false;
        }

        public virtual T[] ToArray()
        {
            T[] array = new T[this.Count];
            int counter = this.Count - 1;

            Node<T> currentNode = this.top;

            while (currentNode != null)
            {
                array[counter--] = currentNode.Item;

                currentNode = currentNode.Next;
            }

            return array;
        }

        private void PushCollection(ICollection<T> collection)
        {
            if (collection.Count == 0)
            {
                return;
            }

            var enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                T item = enumerator.Current;
                this.Push(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = this.top;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            } 
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
