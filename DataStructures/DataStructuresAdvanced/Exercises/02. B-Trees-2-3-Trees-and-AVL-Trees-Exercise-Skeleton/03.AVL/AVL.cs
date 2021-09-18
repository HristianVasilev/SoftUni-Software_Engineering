namespace _03.AVL
{
    using System;
    using System.Text;

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

        public void Delete(T item)
        {
            this.Root = Delete(this.Root, item);
        }

        private Node<T> Delete(Node<T> currentNode, T target)
        {
            if (currentNode == default)
            {
                return default;
            }

            if (target.CompareTo(currentNode.Value) < 0)
            {
                // Left subtree
                currentNode.Left = Delete(currentNode.Left, target);
            }
            else if (target.CompareTo(currentNode.Value) > 0)
            {
                // Right subtree
                currentNode.Right = Delete(currentNode.Right, target);
            }
            else
            {
                // The element is founded
                if (currentNode.Right != default)
                {
                    Node<T> parent = currentNode.Right;

                    while (parent.Left != default)
                    {
                        parent = parent.Left;
                    }

                    currentNode.Value = parent.Value;
                    currentNode.Right = Delete(currentNode.Right, parent.Value);
                }
                else
                {
                    return currentNode.Left;
                }
            }

            currentNode = Balance(currentNode);
            UpdateHeight(currentNode);

            return currentNode;
        }

        public void DeleteMin()
        {
            if (this.Root == default)
            {
                return;
            }

            if (this.Root.Left == default)
            {
                this.Root = this.Root.Right;
                return;
            }

            DeleteMin(ref this.Root.Left);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            GetTreeByDFS(this.Root, ref sb, 0);

            return sb.ToString().TrimEnd();
        }



        // Private methods
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

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private void DeleteMin(ref Node<T> currentNode)
        {
            if (currentNode.Left == default)
            {
                currentNode = currentNode.Right;
                return;
            }

            DeleteMin(ref currentNode.Left);

            UpdateHeight(currentNode);
            currentNode = Balance(currentNode);
        }

        private Node<T> Balance(Node<T> node)
        {
            var balance = Height(node.Left) - Height(node.Right);
            if (balance > 1)
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balance < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
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

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }


        private void GetTreeByDFS(Node<T> node, ref StringBuilder sb, int indent)
        {
            if (node == default)
            {
                return;
            }

            this.GetTreeByDFS(node.Right, ref sb, indent + 3);

            sb.AppendLine($"{new string(' ', indent)}{node.Value}");

            this.GetTreeByDFS(node.Left, ref sb, indent + 3);
        }

    }
}
