using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(
                7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)
                     ),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6)
                     )
                    );
            //** BFS Traversal

            //var result = tree.OrderBfs();
            //Console.WriteLine(string.Join(", ", result));

            //** DFS Traversal

            //var result = tree.OrderDfs();
            //Console.WriteLine(string.Join(", ", result));

            //** Add Child
            //tree.AddChild(21, new Tree<int>(55));

            //** Remove node

            //tree.RemoveNode(129);
            //;

            tree.Swap(19, 14);
        }
    }
}
