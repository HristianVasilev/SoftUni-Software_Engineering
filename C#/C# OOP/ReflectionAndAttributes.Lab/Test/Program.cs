using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static List<List<int>> groupSort(List<int> arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < arr.Count; i++)
            {
                int element = arr[i];

                if (!dict.ContainsKey(element))
                {
                    dict.Add(element, 0);
                }

                dict[element]++;
            }

            List<List<int>> list = new List<List<int>>();

            foreach (var item in dict.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
            {
                list.Add(new List<int>(new int[] { item.Key, item.Value }));
            }

            return list;
        }
    }
}
