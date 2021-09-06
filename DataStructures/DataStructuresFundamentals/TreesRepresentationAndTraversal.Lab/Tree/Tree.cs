namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private bool IsRootDeleted;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = this;
            children = new List<Tree<T>>();
            this.IsRootDeleted = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            this.children = children.ToList();
        }


        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();


        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();

                foreach (var item in subTree.children)
                {
                    queue.Enqueue(item);
                }

                result.Add(subTree.Value);
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            //**Using stack!
            Stack<Tree<T>> stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Count != 0)
            {
                Tree<T> subTree = stack.Pop();

                foreach (var child in subTree.Children)
                {
                    stack.Push(child);
                }

                result.Add(subTree.Value);
            }

            result.Reverse();

            //** Using recursion!

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            //*** Using FindBFS

            //Tree<T> searchedNode = this.FindBFS(parentKey);

            //if (searchedNode == null)
            //{
            //    throw new ArgumentNullException();
            //}
            //searchedNode.children.Add(child);

            //*** Using FindDFS
            Tree<T> searchedNode = this.FindDFS(this, parentKey);

            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }

            searchedNode.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> searchedNode = FindBFS(nodeKey);

            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Value.Equals(nodeKey))
            {
                this.Value = default(T);
                this.Parent = null;
                this.children.Clear();
                this.IsRootDeleted = true;
                return;
            }

            this.children.Remove(searchedNode);
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = FindBFS(firstKey);
            Tree<T> secondNode = FindBFS(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            Tree<T> tempNode = firstNode;
            firstNode = secondNode;
            secondNode = tempNode;
        }

        private Tree<T> FindBFS(T nodeKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> tree = queue.Dequeue();

                if (tree.Value.Equals(nodeKey))
                {
                    return tree;
                }

                foreach (var child in tree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindDFS(Tree<T> node, T nodeKey)
        {
            if (node.Value.Equals(nodeKey))
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                var tree = FindDFS(child, nodeKey);
                if (tree != null)
                {
                    return tree;
                }
            }

            return null;
        }
    }
}
