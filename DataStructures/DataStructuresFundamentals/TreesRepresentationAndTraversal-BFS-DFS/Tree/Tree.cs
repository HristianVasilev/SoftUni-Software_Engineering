namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            List<string> order = new List<string>();
            DFS(this, ref order, 0);

            return string.Join(Environment.NewLine, order);
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            int deepestLevel = 0;
            Tree<T> leftmostNode = null;
            GetDeepestLeftMostNodeWithDFS(1, ref deepestLevel, ref leftmostNode);
            return leftmostNode;
        }

        public List<T> GetLeafKeys()
        {
            List<T> result = new List<T>();

            GetLeafKeysWithDFS(ref result);
            result = result.OrderBy(x => x).ToList();

            return result;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> node = queue.Dequeue();

                if (node.Children.Count > 0 && node.Parent != null)
                {
                    result.Add(node.Key);
                }

                foreach (var child in node.Children)
                {
                    if (child.Children.Count == 0)
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                }
            }

            return result.OrderBy(x => x).ToList();
        }

        public List<T> GetLongestPath()
        {
            int level = 0;
            List<T> longestPath = new List<T>();
            Stack<T> path = new Stack<T>();
            GetLongestPathByDFS(ref path, level, ref longestPath);
            longestPath.Reverse();

            return longestPath;
        }


        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> paths = new List<List<T>>();
            Stack<T> currentPath = new Stack<T>();
            SumWithDFS(ref paths, ref currentPath);

            List<List<T>> result = new List<List<T>>();

            foreach (var path in paths)
            {
                int[] pathKeys = path.Select(x => int.Parse(x.ToString())).ToArray();

                if (pathKeys.Sum() == sum)
                {
                    path.Reverse();
                    result.Add(path);
                }
            }

            return result;
        }


        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> trees = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> tree = queue.Dequeue();

                int treeSum = GetSumOfTreeByBFS(tree, sum);

                if (treeSum == sum)
                {
                    trees.Add(tree);
                }

                foreach (var child in tree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return trees;
        }






        // Help methods

        private void DFS(Tree<T> node, ref List<string> order, int count)
        {
            order.Add($"{new string(' ', count)}{node.Key}");

            foreach (var child in node.Children)
            {
                this.DFS(child, ref order, count + 2);
            }
        }

        private void GetLeafKeysWithDFS(ref List<T> result)
        {
            if (this.Children.Count == 0)
            {
                result.Add(this.Key);
                return;
            }

            foreach (var child in this.Children)
            {
                child.GetLeafKeysWithDFS(ref result);
            }
        }

        private void GetDeepestLeftMostNodeWithDFS(int level, ref int deepestLevel, ref Tree<T> leftmostNode)
        {
            if (this.Children.Count == 0 && level > deepestLevel)
            {
                deepestLevel = level;
                leftmostNode = this;
                return;
            }

            foreach (var child in this.Children)
            {
                child.GetDeepestLeftMostNodeWithDFS(level + 1, ref deepestLevel, ref leftmostNode);
            }
        }

        private void GetLongestPathByDFS(ref Stack<T> path, int level, ref List<T> longestPath)
        {
            path.Push(this.Key);

            if (path.Count > longestPath.Count)
            {
                longestPath = path.ToList();
            }

            foreach (var child in this.Children)
            {
                child.GetLongestPathByDFS(ref path, level, ref longestPath);
                path.Pop();
            }
        }

        private void SumWithDFS(ref List<List<T>> paths, ref Stack<T> currentPath)
        {
            currentPath.Push(this.Key);

            if (this.Children.Count == 0)
            {
                paths.Add(currentPath.ToList());
                return;
            }

            foreach (var child in this.Children)
            {
                child.SumWithDFS(ref paths, ref currentPath);
                currentPath.Pop();
            }
        }

        private int GetSumOfTreeByBFS(Tree<T> tree, int sum)
        {
            int treeSum = 0;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(tree);

            while (queue.Count != 0)
            {
                Tree<T> node = queue.Dequeue();
                int nodeValue = int.Parse(node.Key.ToString());

                treeSum += nodeValue;
                if (treeSum > sum)
                {
                    return treeSum;
                }

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return treeSum;
        }

    }
}
