namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] lineArgs = line.Split(' ').Select(int.Parse).ToArray();

                CreateNodeByKey(lineArgs[0]);
                CreateNodeByKey(lineArgs[1]);

                AddEdge(lineArgs[0], lineArgs[1]);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            return nodesBykeys.First(x => x.Value.Parent == null).Value;
        }
    }
}
