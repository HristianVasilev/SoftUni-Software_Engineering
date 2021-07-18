namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;

        public ReversedList() : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
            this.Count = 0;
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);

                return this.items[this.Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            CheckAboutGrow();

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            index = this.Count  - index;

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            index = this.Count - index;

            ValidateIndex(index);

            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private void CheckAboutGrow()
        {
            if (this.Count == this.items.Length)
            {
                this.items = Grow();
            }
        }

        private T[] Grow()
        {
            T[] newArray = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                newArray[i] = this.items[i];
            }

            return newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}