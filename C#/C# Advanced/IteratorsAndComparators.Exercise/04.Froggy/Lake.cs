using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public void OrderStones()
        {
            List<int> even = new List<int>();
            List<int> odd = new List<int>();

            for (int i = 0; i < this.stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even.Add(this.stones[i]);
                }
                else
                {
                    odd.Add(this.stones[i]);
                }
            }

            List<int> newStonesCollections = new List<int>();

            odd.Reverse();

            newStonesCollections.AddRange(even);
            newStonesCollections.AddRange(odd);

            this.stones = newStonesCollections.ToArray();
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var stone in this.stones)
            {
                yield return stone;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
