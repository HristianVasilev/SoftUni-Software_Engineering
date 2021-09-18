namespace TestFunctionality
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Cruncher
    {
        private class Node
        {
            public Node(string syllable, List<Node> nextSyllables)
            {
                Syllable = syllable;
                NextSyllables = nextSyllables;
            }

            public string Syllable { get; set; }
            public List<Node> NextSyllables { get; set; }
        }

        private List<Node> syllableGroups;

        public Cruncher(string[] syllables, string targetWord)
        {
            this.syllableGroups = new List<Node>();
            this.syllableGroups = this.GenerateSyllablesGroups(syllables, targetWord);
        }

        private List<Node> GenerateSyllablesGroups(string[] syllables, string targetWord)
        {
            if (string.IsNullOrEmpty(targetWord) || syllables.Length == 0)
            {
                return null;
            }

            List<Node> resultValues = new List<Node>();

            for (int i = 0; i < syllables.Length; i++)
            {
                string syllable = syllables[i];

                if (targetWord.StartsWith(syllable))
                {
                    var nextSyllables = this.GenerateSyllablesGroups(
                          syllables.Where((val, index) => index != i).ToArray(),
                          targetWord.Substring(syllable.Length)
                          );

                    resultValues.Add(new Node(syllable, nextSyllables));
                }

            }

            return resultValues;
        }

        public HashSet<string> GetSyllablePaths()
        {
            var allPaths = new List<List<string>>();
            this.ReconstructPaths(this.syllableGroups, new Stack<string>(), allPaths);
            return new HashSet<string>(allPaths.Select(l => string.Join(' ', l)));
        }

        private void ReconstructPaths(List<Node> nodes, Stack<string> currentPath, List<List<string>> allPaths)
        {
            if (nodes == null)
            {
                allPaths.Add(new List<string>(currentPath.Reverse()));
                return;
            }

            foreach (var node in nodes)
            {
                currentPath.Push(node.Syllable);

                this.ReconstructPaths(node.NextSyllables, currentPath, allPaths);

                currentPath.Pop();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string[] syllables = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string targetWord = Console.ReadLine();

            Cruncher cruncher = new Cruncher(syllables, targetWord);

            foreach (var item in cruncher.GetSyllablePaths())
            {
                Console.WriteLine(item);
            }

        }
    }
}
