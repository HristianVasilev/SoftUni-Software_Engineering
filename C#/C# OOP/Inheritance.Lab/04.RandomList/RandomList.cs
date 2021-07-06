using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, base.Count - 1);

            string randomElement = base[randomIndex];
            base.RemoveAt(randomIndex);

            return randomElement;
        }

    }
}
