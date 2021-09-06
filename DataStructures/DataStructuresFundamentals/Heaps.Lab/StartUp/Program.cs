using _01.BinaryTree;
using System;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractBinaryTree<int> tree = new BinaryTree<int>(
                17,
                new BinaryTree<int>(
                    9,
                    new BinaryTree<int>(3, null, null),
                    new BinaryTree<int>(11, null, null)),
                new BinaryTree<int>(
                    25,
                    new BinaryTree<int>(20, null, null),
                    new BinaryTree<int>(31, null, null))
            );

            var listInOrder = tree.InOrder();
            Console.WriteLine(string.Join(" ", listInOrder));  

        }
    }
}
