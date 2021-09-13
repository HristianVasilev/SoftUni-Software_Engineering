namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int capacity = 8;
        private const int factor = 75;

        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private int fillFactor => this.CalculateFillFactor();



        public HashTable() : this(capacity) { }

        public HashTable(int capacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.Count = 0;
        }


        public int Count { get; private set; }

        public int Capacity => this.slots.Length;



        public void Add(TKey key, TValue value)
        {
            // Note: throw an exception on duplicated key
            this.GrowIfNeeded();
            this.Add(key, value, ref this.slots);
        }


        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                this.Add(key, value);
                return true;
            }
            catch (ArgumentException ex)
            {
                if (ex.Message.Equals($"Key already exists: {key}"))
                {
                    int slotNumber = this.FindSlotNumber(key);
                    KeyValue<TKey, TValue> element = this.slots[slotNumber].First(k => k.Key.Equals(key));
                    element.Value = value;
                    return false;
                }
                else
                {
                    throw ex;
                }
            }

        }

        public TValue Get(TKey key)
        {
            // Note: throw an exception on missing key
            KeyValue<TKey, TValue> element = this.Find(key);
            if (element == default)
            {
                throw new KeyNotFoundException();
            }

            return element.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                // Note: throw an exception on missing key
                KeyValue<TKey, TValue> result = this.Find(key);
                if (result == default)
                {
                    throw new ArgumentNullException();
                }

                return result.Value;
            }
            set
            {
                KeyValue<TKey, TValue> result = this.Find(key);
                result.Value = value;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);

            return this.slots[slotNumber]?.FirstOrDefault(k => k.Key.Equals(key));
        }

        public bool ContainsKey(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);

            return this.slots[slotNumber] != null;
        }

        public bool Remove(TKey key)
        {
            int slotNumber = this.FindSlotNumber(key);

            if (this.slots[slotNumber] == default) return false;

            KeyValue<TKey, TValue> target = default;
            bool targetExists = false;
            foreach (var element in this.slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    target = element;
                    targetExists = true;
                    this.Count--;
                    break;
                }
            }

            this.slots[slotNumber].Remove(target);

            return targetExists;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot == null) continue;

                foreach (var element in slot)
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        // Private methods


        // Add funtionality

        private void Add(TKey key, TValue value, ref LinkedList<KeyValue<TKey, TValue>>[] slots)
        {
            int slotNumber = FindSlotNumber(key);

            if (slots[slotNumber] == null)
            {
                slots[slotNumber] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            CheckForDuplicates(key, slotNumber, slots);

            KeyValue<TKey, TValue> newElement = new KeyValue<TKey, TValue>(key, value);
            slots[slotNumber].AddLast(newElement);
            this.Count++;
        }

        private void GrowIfNeeded()
        {
            if (this.fillFactor < factor) return;

            LinkedList<KeyValue<TKey, TValue>>[] resizedSlot
                = new LinkedList<KeyValue<TKey, TValue>>[capacity * 2];
            this.Count = 0;

            for (int i = 0; i < this.slots.Length; i++)
            {
                if (this.slots[i] == null) continue;

                foreach (var element in this.slots[i])
                {
                    this.Add(element.Key, element.Value, ref resizedSlot);
                }
            }

            this.slots = resizedSlot;
        }

        private void CheckForDuplicates(TKey key, int slotNumber, LinkedList<KeyValue<TKey, TValue>>[] slots)
        {
            foreach (var element in slots[slotNumber])
            {
                if (element.Key.Equals(key))
                {
                    throw new ArgumentException($"Key already exists: {key}");
                }
            }
        }




        // Other

        private int FindSlotNumber(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % this.Capacity;
        }

        private int CalculateFillFactor()
        {
            return (int)(((double)this.Count / (double)this.Capacity) * 100);
        }
    }
}
