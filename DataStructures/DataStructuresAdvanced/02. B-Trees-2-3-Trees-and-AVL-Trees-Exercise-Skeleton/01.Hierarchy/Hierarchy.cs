namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    
    public class Hierarchy<T> : IHierarchy<T>
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Children = new List<Node>();
            }
            public T Value { get; set; }
            public List<Node> Children { get; set; }
        }

        private Node root;
        private Dictionary<T, Node> nodesByValue;
        private Dictionary<T, Node> parentsByChildValue;

        public Hierarchy(T value)
        {
            this.root = new Node(value);
            this.nodesByValue = new Dictionary<T, Node>();
            this.parentsByChildValue = new Dictionary<T, Node>();

            this.nodesByValue.Add(value, this.root);
            this.parentsByChildValue.Add(value, null);
        }

        public int Count => this.nodesByValue.Count;

        public void Add(T parentValue, T childValue)
        {
            if (!this.nodesByValue.ContainsKey(parentValue)
                || this.nodesByValue.ContainsKey(childValue))
            {
                throw new ArgumentException("Parent node doesn't exists or child alredy exists!");
            }

            Node childNode = new Node(childValue);
            this.nodesByValue.Add(childValue, childNode);
            this.parentsByChildValue.Add(childValue, this.nodesByValue[parentValue]);
            this.nodesByValue[parentValue].Children.Add(childNode);
        }

        public void Remove(T elementValue)
        {
            if (this.root.Value.Equals(elementValue))
            {
                throw new InvalidOperationException("The root of the tree cannot be removed!");
            }

            if (!this.nodesByValue.ContainsKey(elementValue))
            {
                throw new ArgumentException("The element doesn't exists and it cannot be removed!");
            }

            Node element = this.nodesByValue[elementValue];
            List<Node> children = element.Children;
            Node parentNode = this.parentsByChildValue[elementValue];
            T parentValue = parentNode.Value;

            this.parentsByChildValue.Remove(elementValue);
            this.nodesByValue.Remove(elementValue);
            this.nodesByValue[parentValue].Children.Remove(element);

            foreach (var child in children)
            {
                this.nodesByValue[parentValue].Children.Add(child);
                this.parentsByChildValue[child.Value] = parentNode;
            }

        }

        public IEnumerable<T> GetChildren(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException("The element doesn't exists!");
            }

            return this.nodesByValue[element].Children.Select(x => x.Value);
        }

        public T GetParent(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException("Element's parent wasn't correct!");
            }

            Node node = this.parentsByChildValue[element];

            return node == null ? default(T) : node.Value;
        }

        public bool Contains(T element)
        {
            return this.nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            return this.nodesByValue.Keys.Intersect(other.nodesByValue.Keys);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(this.root);

            while (queue.Count != 0)
            {
                Node node = queue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}