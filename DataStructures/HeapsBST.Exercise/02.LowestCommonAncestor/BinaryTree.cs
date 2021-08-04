namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }

        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            //Stack<T> parentsOfFirstSubTree = new Stack<T>();
            //GoToSubtree(first, this, ref parentsOfFirstSubTree);

            //Stack<T> parentsOfSecondSubTree = new Stack<T>();
            //GoToSubtree(second, this, ref parentsOfSecondSubTree);

            //var result = parentsOfFirstSubTree.Intersect(parentsOfSecondSubTree).First();

            BinaryTree<T> firstTree = FindTree(first, this);
            BinaryTree<T> secondTree = FindTree(second, this);

            T[] firstTreeAncestors = GetAncestors(firstTree);
            T[] secondTreeAncestors = GetAncestors(secondTree);

            T result = firstTreeAncestors.Intersect(secondTreeAncestors).First();

            return result;
        }

        private T[] GetAncestors(BinaryTree<T> binaryTree)
        {
            List<T> result = new List<T>();

            while (binaryTree != null)
            {
                result.Add(binaryTree.Parent.Value);
                binaryTree = binaryTree.Parent;
            }

            return result.ToArray();
        }

        private void GoToSubtree(T element, BinaryTree<T> binaryTree, ref Stack<T> parents)
        {
            if (binaryTree.Value.Equals(element))
            {
                return;
            }

            parents.Push(binaryTree.Value);

            if (element.CompareTo(binaryTree.Value) > 0)
            {
                GoToSubtree(element, binaryTree.RightChild, ref parents);
            }
            else if (element.CompareTo(binaryTree.Value) < 0)
            {
                GoToSubtree(element, binaryTree.LeftChild, ref parents);
            }
        }

        private BinaryTree<T> FindTree(T element, BinaryTree<T> binaryTree)
        {
            if (binaryTree == null)
            {
                throw new ArgumentException("The element doesn't exists!");
            }

            if (element.Equals(binaryTree.Value))
            {
                return binaryTree;
            }

            BinaryTree<T> result;

            if (element.CompareTo(binaryTree.Value) > 0)
            {
                return binaryTree.RightChild.FindTree(element, binaryTree.RightChild);
            }
            else if (element.CompareTo(binaryTree.Value) < 0)
            {
                return binaryTree.LeftChild.FindTree(element, binaryTree.LeftChild);
            }

            throw new ArgumentNullException();
        }
    }
}
