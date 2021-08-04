using _03.MinHeap;
using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            MinHeap<int> bag = new MinHeap<int>();

            foreach (var cookie in cookies)
            {
                bag.Add(cookie);
            }

            int smallestElement = bag.Peek();
            int steps = 0;

            while (smallestElement < k && bag.Size > 1)
            {
                int smallestCookie = bag.Dequeue();
                int secondSmallestCookie = bag.Dequeue();

                steps++;
                bag.Add(smallestCookie + 2 * secondSmallestCookie);
                smallestElement = bag.Peek();
            }

            return smallestElement > k ? steps : -1;

            // OrderedBag<int> bag = new OrderedBag<int>(cookies);

            //int smallestElement = bag.GetFirst();
            //int steps = 0;

            //while (smallestElement < k && bag.Count > 1)
            //{
            //    int smallestCookie = bag.RemoveFirst();
            //    int secondSmallestCookie = bag.RemoveFirst();

            //    steps++;

            //    bag.Add(smallestCookie + 2 * secondSmallestCookie);
            //    smallestElement = bag.GetFirst();
            //}

            //return smallestElement > k ? steps : -1;
        }
    }
}
