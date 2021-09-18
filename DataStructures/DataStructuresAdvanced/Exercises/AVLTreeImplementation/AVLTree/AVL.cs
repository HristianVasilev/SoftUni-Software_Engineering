namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            UpdateBalanceFactor(ref node);
            node = Balance(node);
            return node;
        }

        private Node<T> Balance(Node<T> node)
        {
            if (node.BalanceFactor == -2)
            {
                if (node.Left.BalanceFactor > 0)
                {
                    node = LeftRightRotation(node);
                }
                else
                {
                    node = RighRightRotation(node);
                }
            }
            else if (node.BalanceFactor == 2)
            {
                if (node.Right.BalanceFactor < 0)
                {
                    node = RightLeftRotation(node);
                }
                else
                {
                    node = LeftLeftRotation(node);
                }
            }

            return node;
        }

        private void UpdateBalanceFactor(ref Node<T> node)
        {
            int leftHeight = 0;
            int rightHeight = 0;

            if (node.Left != null)
            {
                leftHeight = node.Left.Height;
            }
            if (node.Right != null)
            {
                rightHeight = node.Right.Height;
            }

            node.Height = 1 + Math.Max(leftHeight, rightHeight);

            node.BalanceFactor = rightHeight - leftHeight;
        }



        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }


        private Node<T> LeftLeftRotation(Node<T> node)
        {
            return LeftRotation(node);
        }

        private Node<T> LeftRightRotation(Node<T> node)
        {
            node.Left = LeftLeftRotation(node.Left);
            return RighRightRotation(node);
        }



        private Node<T> RighRightRotation(Node<T> node)
        {
            return RightRotation(node);
        }

        private Node<T> RightLeftRotation(Node<T> node)
        {
            node.Right = RighRightRotation(node.Right);
            return LeftLeftRotation(node);
        }



        private Node<T> LeftRotation(Node<T> node)
        {
            Node<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            UpdateBalanceFactor(ref node);
            UpdateBalanceFactor(ref newNode);

            return newNode;
        }

        private Node<T> RightRotation(Node<T> node)
        {
            Node<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            UpdateBalanceFactor(ref node);
            UpdateBalanceFactor(ref newNode);

            return newNode;
        }

    }
}
