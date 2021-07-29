namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild
        {
            get;
            private set;
        }

        public Node<T> RightChild
        {
            get;
            private set;
        }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            Node<T> current = this.Root;

            while (current != null)
            {
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                else if (element.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }

            return current != null;
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
                return;
            }

            Node<T> node = this.Root;

            while (true)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new Node<T>(element, null, null);
                        return;
                    }

                    node = node.LeftChild;
                }
                else
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = new Node<T>(element, null, null);
                        return;
                    }

                    node = node.RightChild;
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {        
            Node<T> node = this.Root;

            while (node.Value.CompareTo(element) != 0)
            {
                if (element.CompareTo(node.Value) > 0)
                {
                    node = node.RightChild;
                }
                else if (element.CompareTo(node.Value) < 0)
                {
                    node = node.LeftChild;
                }
            }

            return new BinarySearchTree<T>(node);
        }
    }
}
