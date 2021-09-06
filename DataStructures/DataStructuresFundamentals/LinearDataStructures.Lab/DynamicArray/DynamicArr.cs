using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
    public class DynamicArr<T> : IEnumerable<T>
    {
        private T[] array;
        private int index;

        public DynamicArr(int capacity = 4)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.array = new T[capacity];
            this.index = 0;
        }


        public int Count { get => this.index; }
        public int Capacity
        {
            get => this.array.Length;
            set
            {
                if (value != this.array.Length)
                {
                    Grow(value);
                }
            }
        }
        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.array[index];
            }
            set
            {
                ValidateIndex(index);
                this.array[index] = value;
            }
        }


        public void Add(T item)
        {
            GrowIfNecessary();

            this.array[index++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("source");
            }

            IEnumerator<T> iterator = collection.GetEnumerator();
            try
            {
                while (iterator.MoveNext())
                {
                    T item = iterator.Current;
                    Add(item);
                }
            }
            finally
            {
                IDisposable disposable = iterator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        public void Clear()
        {
            this.array = new T[this.Capacity];
            this.index = 0;
        }

        public bool Exists(Predicate<T> match)
        {
            for (int i = 0; i < this.Count; i++)
            {
                bool isMatched = match.Invoke(this.array[i]);

                if (isMatched)
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index == this.index)
            {
                throw new IndexOutOfRangeException();
            }

            GrowIfNecessary();

            for (int i = this.Count; i > index; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.index++;
            this.array[index] = item;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index > this.index)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            this.index--;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this.array.Length)
            {
                Grow();
            }


        }

        private void Grow()
        {
            Grow(this.array.Length * 2);
        }

        private void Grow(int capacity)
        {
            T[] newArray = new T[capacity];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
