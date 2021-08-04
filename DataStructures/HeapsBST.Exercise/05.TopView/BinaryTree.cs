namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            Dictionary<int, (T nodeValue, int nodeLevel)> dictionary = new Dictionary<int, (T nodeValue, int nodeLevel)>();

            this.TopView(this, 0, 0, ref dictionary);

            return dictionary.Select(x => x.Value.nodeValue).ToList();
        }


        private void TopView(BinaryTree<T> binaryTree, int dist, int level,
            ref Dictionary<int, (T nodeValue, int nodeLevel)> dictionary)
        {
            if (binaryTree == null)
            {
                return;
            }

            if (dictionary.ContainsKey(dist))
            {
                if (dictionary[dist].nodeLevel > level)
                {
                    dictionary[dist] = (binaryTree.Value, level);
                }
            }
            else
            {
                dictionary.Add(dist, (binaryTree.Value, level));
            }

            this.TopView(binaryTree.LeftChild, dist - 1, level + 1, ref dictionary);
            this.TopView(binaryTree.RightChild, dist + 1, level + 1, ref dictionary);
        }
    }
}
