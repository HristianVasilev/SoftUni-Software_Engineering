using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public Stack()
        {
            this.collection = new List<T>();
        }

        public void Push(T element)
        {
            this.collection.Add(element);
        }

        public T Pop()
        {
            if (this.collection.Count == 0)
            {
                throw new System.ArgumentException("No elements");
            }

            T element = this.collection.LastOrDefault();
            this.collection.RemoveAt(this.collection.Count - 1);

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
