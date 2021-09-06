using _01.BSTOperations;
using _02.LowestCommonAncestor;
using _03.MinHeap;
using _04.CookiesProblem;
using System;
using System.Text;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = new CookiesProblem().Solve(7, new int[] { 1, 2, 3, 9, 10, 12 });
            Console.WriteLine(result);

            int result2 = new CookiesProblem().Solve(10, new int[] { 1, 1, 1, 1 });
            Console.WriteLine(result2);
        }
    }
}
