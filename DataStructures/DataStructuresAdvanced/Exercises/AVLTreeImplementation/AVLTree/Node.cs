namespace AVLTree
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public int Height;
        public int BalanceFactor { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Height = 1;
            this.BalanceFactor = 0;
        }


    }
}
