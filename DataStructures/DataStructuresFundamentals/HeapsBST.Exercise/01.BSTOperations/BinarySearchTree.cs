namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            if (root != null)
            {
                this.Root = root;
                this.Count++;
            }
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            Node<T> node = this.Root;

            if (node == null)
            {
                return false;
            }

            while (node != null)
            {
                if (node.Value.Equals(element))
                {
                    return true;
                }

                if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else if (element.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            this.Root = Insert(element, this.Root);
        }

        private Node<T> Insert(T element, Node<T> root)
        {
            if (root == null)
            {
                this.Count++;
                return new Node<T>(element, null, null);
            }

            if (element.CompareTo(root.Value) > 0)
            {
                root.RightChild = Insert(element, root.RightChild);
            }
            else
            {
                root.LeftChild = Insert(element, root.LeftChild);
            }

            return root;
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            Node<T> node = this.Root;

            if (node == null)
            {
                throw new ArgumentNullException("Binary search tree is empty!");
            }

            while (!node.Value.Equals(element))
            {
                if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    node = node.LeftChild;
                }
            }

            if (!node.Value.Equals(element))
            {
                throw new ArgumentException("Binary search tree doesn't contais that element!");
            }

            return new BinarySearchTree<T>(node);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, this.Root);
        }

        public List<T> Range(T lower, T upper)
        {
            List<T> collection = new List<T>();

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();

                if (InRange(lower, upper, node))
                {
                    collection.Add(node.Value);
                }

                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }

            return collection;
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("The tree is empty!");
            }

            this.Root = DeleteMin(this.Root);
        }

        public void DeleteMax()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("The tree is empty!");
            }

            this.Root = DeleteMax(this.Root);
        }


        public int GetRank(T element)
        {
            int counter = 0;
            CountSmallerElements(element, this.Root, ref counter);

            return counter;
        }




        private void CountSmallerElements(T element, Node<T> node, ref int counter)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value.CompareTo(element) == -1)
            {
                counter++;
            }

            CountSmallerElements(element, node.LeftChild, ref counter);
            CountSmallerElements(element, node.RightChild, ref counter);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(action, node.LeftChild);
            action.Invoke(node.Value);
            EachInOrder(action, node.RightChild);
        }

        private static bool InRange(T lower, T upper, Node<T> node)
        {
            return lower.CompareTo(node.Value) <= 0 && upper.CompareTo(node.Value) >= 0;
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                this.Count--;
                if (node.RightChild == null)
                {
                    return null;
                }

                return node.RightChild;
            }

            node.LeftChild = DeleteMin(node.LeftChild);
            return node;
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                this.Count--;
                if (node.LeftChild == null)
                {
                    return null;
                }

                return node.LeftChild;
            }

            node.RightChild = DeleteMax(node.RightChild);
            return node;
        }

    }
}
