namespace TestTheTrees
{
    using _03.AVL;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            AVL<int> avl = new AVL<int>();
            for (int i = 1; i < 10; i++)
            {
                avl.Insert(i);
            }

            Console.WriteLine(avl.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('_',20));

            avl.Delete(4);

            Console.WriteLine(avl.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('_', 20));

            avl.Delete(2);

            Console.WriteLine(avl.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('_', 20));

            avl.Delete(1);

            Console.WriteLine(avl.ToString());
            Console.WriteLine();
            Console.WriteLine(new string('_', 20));



        }
    }
}
