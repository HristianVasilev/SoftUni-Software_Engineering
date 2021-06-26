using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.Collection
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndex = 0;

        public ListyIterator(params T[] items)
        {
            this.collection = new List<T>(items);
        }

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                this.currentIndex++;
            }

            return canMove;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.collection[this.currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(' ', this.collection));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.collection)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
