namespace RedBlackTree
{
    using System;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            RedBlackTree redBlackTree = new RedBlackTree();

            redBlackTree.Insert(2);
            redBlackTree.Insert(1);
            redBlackTree.Insert(3);
            redBlackTree.Insert(4);
            

            redBlackTree.ConsolePrint(redBlackTree.Root, 0);
        }
    }
}
