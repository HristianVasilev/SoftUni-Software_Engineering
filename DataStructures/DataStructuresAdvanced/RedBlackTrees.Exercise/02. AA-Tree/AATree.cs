namespace _02._AA_Tree
{
    using System;
    using System.Collections.Generic;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int CountNodes()
        {
            return CountNodes(this.root);
        }


        public bool IsEmpty()
        {
            return this.root == default;
        }

        public void Clear()
        {
            this.root = default;
        }

        public void Insert(T element)
        {
            if (this.root == default)
            {
                this.root = new Node<T>(element);
                return;
            }

            this.root = this.Insert(this.root, element);
        }

        public bool Search(T element)
        {
            if (this.root == default)
            {
                return false;
            }

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(this.root);

            while (queue.Count != 0)
            {
                Node<T> node = queue.Dequeue();

                if (node.Element.Equals(element)) return true;

                if (element.CompareTo(node.Element) < 0)
                {
                    if (node.Left != null) queue.Enqueue(node.Left);
                }
                else
                {
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
            }

            return false;
        }

        // Order methods

        public void InOrder(Action<T> action)
        {
            if (this.root == default)
            {
                return;
            }

            InOrder(this.root, action);
        }

        public void PreOrder(Action<T> action)
        {
            if (this.root == default)
            {
                return;
            }

            PreOrder(this.root, action);
        }

        public void PostOrder(Action<T> action)
        {
            if (this.root == default)
            {
                return;
            }

            PostOrder(this.root, action);
        }


        // Private methods

        private int CountNodes(Node<T> node)
        {
            if (node == default)
            {
                return 0;
            }

            return 1 + this.CountNodes(node.Left) + this.CountNodes(node.Right);
        }

        private Node<T> Insert(Node<T> currentNode, T element)
        {
            if (currentNode == default)
            {
                return new Node<T>(element);
            }

            if (element.CompareTo(currentNode.Element) < 0)
            {
                currentNode.Left = Insert(currentNode.Left, element);
            }
            else if (element.CompareTo(currentNode.Element) > 0)
            {
                currentNode.Right = Insert(currentNode.Right, element);
            }
            else
            {
                throw new InvalidOperationException("You cannot insert an already existing element!");
            }

            currentNode = this.Skew(currentNode);
            currentNode = this.Split(currentNode);

            return currentNode;
        }

        private Node<T> Skew(Node<T> currentNode)
        {
            if (currentNode.Left != null && currentNode.Left.Level == currentNode.Level)
            {
                currentNode = LeftRotation(currentNode);
            }

            return currentNode;
        }

        private Node<T> Split(Node<T> currentNode)
        {
            if (currentNode.Right != null && currentNode.Right?.Right != null && currentNode.Right.Right.Level == currentNode.Level)
            {
                currentNode = RightRotation(currentNode);
                currentNode.Level++;
            }

            return currentNode;
        }

        private Node<T> LeftRotation(Node<T> node)
        {
            Node<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }

        private Node<T> RightRotation(Node<T> currentNode)
        {
            Node<T> newNode = currentNode.Right;
            currentNode.Right = newNode.Left;
            newNode.Left = currentNode;

            return newNode;
        }


        private void InOrder(Node<T> node, Action<T> action)
        {
            if (node == default)
            {
                return;
            }

            InOrder(node.Left, action);
            action(node.Element);

            if (node.Right != default)
            {
                if (node.Right.IsLeaf())
                {
                    action(node.Right.Element);
                    return;
                }

                InOrder(node.Right, action);
            }

        }

        private void PreOrder(Node<T> node, Action<T> action)
        {
            if (node == default)
            {
                return;
            }

            action(node.Element);
            PreOrder(node.Left, action);

            if (node.Right != default)
            {
                if (node.Right.IsLeaf())
                {
                    action(node.Right.Element);
                    return;
                }

                PreOrder(node.Right, action);
            }
        }

        private void PostOrder(Node<T> node, Action<T> action)
        {
            if (node == default)
            {
                return;
            }

            PostOrder(node.Left, action);
            PostOrder(node.Right, action);
            action(node.Element);
        }
    }
}