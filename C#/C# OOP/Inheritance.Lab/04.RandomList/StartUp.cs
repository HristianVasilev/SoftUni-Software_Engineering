using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("AAA");
            randomList.Add("BBB");
            randomList.Add("CCC");
            randomList.Add("DDD");
            randomList.Add("EEE");
            randomList.Add("FFF");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
