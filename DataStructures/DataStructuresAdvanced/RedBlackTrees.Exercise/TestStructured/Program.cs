namespace TestStructured
{
    using _01.Red_Black_Tree;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree<string> RedBlackTree;
            string[] input = {
                "S",
                "E",
                "A",
                "R",
                "C",
                "H",
                "E",
                "X",
                "A",
                "M",
                "P",
                "L",
                "E"
            };

            RedBlackTree = new RedBlackTree<string>();

            for (int i = 0; i < input.Length; i++)
            {
                RedBlackTree.Insert(input[i]);
            }

            Console.WriteLine(RedBlackTree.ToString());
            Console.WriteLine(new string('_', 10));

            RedBlackTree.DeleteMin();
            RedBlackTree.DeleteMin();


            Console.WriteLine(RedBlackTree.ToString());


        }
    }
}
