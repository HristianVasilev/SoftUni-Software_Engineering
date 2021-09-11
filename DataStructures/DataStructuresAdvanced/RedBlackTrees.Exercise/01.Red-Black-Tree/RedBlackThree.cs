namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        private Node root;

        public RedBlackTree() { }

        public int Count => this.CountNodes(this.root);

        public void Insert(T element)
        {
            this.root = Insert(this.root, element);
            this.root.Color = Black;
        }

        public T Select(int rank)
        {
            throw new NotImplementedException();
        }

        public int Rank(T element)
        {
            return 0;
        }

        public bool Contains(T element)
        {
            return Contains(this.root, element);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node node = Search(this.root, element);

            RedBlackTree<T> tree = new RedBlackTree<T>();
            tree.root = node;
            return tree;
        }


        public void DeleteMin()
        {
            if (this.root == default)
            {
                return;
            }

            this.root = DeleteMin(this.root);
        }


        public void DeleteMax()
        {
            if (this.root == default)
            {
                return;
            }

            this.root = DeleteMax(this.root);
        }



        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public void Delete(T element)
        {
            this.root = this.Delete(this.root, element);
        }

        public T Ceiling(T element)
        {
            if (this.root == default)
            {
                throw new ArgumentNullException("The tree is empty!");
            }

            return this.Ceiling(this.root, default, element);
        }

        public T Floor(T element)
        {
            if (this.root == default)
            {
                throw new ArgumentNullException("The tree is empty!");
            }

            return this.Floor(this.root, element);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return this.GetEachInOrderAsString(this.root, 0);
        }


        // Private methods

        private int CountNodes(Node node)
        {
            if (node == default) return 0;

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }


        // Insertion

        private Node Insert(Node node, T element)
        {
            if (node == default)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, element);
            }

            node = Rebalance(node);

            return node;
        }

        private Node Rebalance(Node node)
        {
            if (!this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                // Left rotation
                node = this.LeftRotation(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Left.Left))
            {
                // Right rotation
                node = this.RightRotation(node);
            }
            if (this.IsRed(node.Left) && this.IsRed(node.Right))
            {
                // Flip colors
                this.SwapColors(node);
            }

            return node;
        }

        private Node LeftRotation(Node node)
        {
            Node newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            newNode.Color = node.Color;
            node.Color = Red;

            return newNode;
        }

        private Node RightRotation(Node node)
        {
            Node newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            newNode.Color = node.Color;
            node.Color = Red;

            return newNode;
        }

        private void SwapColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }


        // Searching

        private bool Contains(Node node, T element)
        {
            Node returnedNode = this.Search(node, element);

            if (returnedNode != default)
            {
                return true;
            }

            return false;
        }

        private Node Search(Node node, T element)
        {
            if (node == default)
            {
                return default;
            }

            if (node.Value.Equals(element))
            {
                return node;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return this.Search(node.Left, element);
            }
            else
            {
                return this.Search(node.Right, element);
            }
        }


        // Deletion

        private Node Delete(Node node, T element)
        {
            if (node == default)
            {
                return default;
            }

            int compare = element.CompareTo(node.Value);

            if (compare == 0)
            {
                if (node.Right == default)
                {
                    return node.Left;
                }
                else if (node.Left == default)
                {
                    return node.Right;
                }

                Node copyNode = node;
                node = FindSmallestChild(copyNode.Right);
                if (node.Right != default) node.Right = DeleteMin(node.Right);
                node.Left = copyNode.Left;
            }
            else if (compare < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else
            {
                node.Right = this.Delete(node.Right, element);
            }

            node.Count = CountNodes(node);

            return node;
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == default)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);
            node.Count = this.CountNodes(node);
            return node;
        }
        private Node DeleteMin(Node node)
        {
            if (node.Left == default)
            {
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);
            node.Count = this.CountNodes(node);
            return node;
        }


        private Node FindSmallestChild(Node node)
        {
            if (node.Left == default)
            {
                return node;
            }

            return this.FindSmallestChild(node.Left);
        }


        // Other
        private bool IsRed(Node node)
        {
            if (node == default) return false;

            return node.Color == Red;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == default)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private T Ceiling(Node node, T parentValue, T element)
        {
            if (node == default)
            {
                return parentValue;
            }

            T result;

            if (element.Equals(node.Value))
            {
                result = parentValue;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                result = this.Ceiling(node.Left, node.Value, element);
            }
            else
            {
                result = this.Ceiling(node.Right, node.Value, element);
            }

            return result;
        }

        private T Floor(Node node, T element)
        {
            T result;
            if (element.Equals(node.Value))
            {
                result = node.Value;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                if (node.Left == default)
                {
                    result = node.Value;
                }
                else
                {
                    result = this.Floor(node.Left, element);
                }
            }
            else
            {
                if (node.Right == default)
                {
                    result = node.Value;
                }
                else
                {
                    result = this.Floor(node.Right, element);
                }
            }

            return result;
        }


        private string GetEachInOrderAsString(Node node, int indent)
        {
            StringBuilder sb = new StringBuilder();

            if (node.Right != default)
            {
                sb.Append(this.GetEachInOrderAsString(node.Right, indent + 3));
            }

            sb.AppendLine($"{new string(' ', indent)}{node.Value}");

            if (node.Left != default)
            {
                sb.Append(this.GetEachInOrderAsString(node.Left, indent + 3));
            }

            return sb.ToString();
        }


        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
            public int Count { get; set; }

            public override string ToString()
            {
                return $"V:{this.Value} - L:{this.Left != default}, R:{this.Right != default}";
            }
        }
    }
}