using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Compose> composes = new List<Compose>();

            byte n = byte.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');

                AddCompose(tokens, ref composes);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command.Split('|');
                string action = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                switch (action)
                {
                    case "Add":
                        AddCompose(tokens, ref composes, true);
                        break;
                    case "Remove":
                        Remove(tokens, ref composes);
                        break;
                    case "ChangeKey":
                        ChangeKey(tokens, ref composes);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintAllComposesSorted(ref composes);
        }

        private static void PrintAllComposesSorted(ref List<Compose> composes)
        {
            var collection = composes.OrderBy(x => x.Piece).ThenBy(x => x.Composer);

            foreach (var compose in collection)
            {
                Console.WriteLine(compose.ToString());
            }
        }

        private static void ChangeKey(string[] tokens, ref List<Compose> composes)
        {
            string piece = tokens[0];
            string newKey = tokens[1];

            Compose compose = composes.FirstOrDefault(x => x.Piece == piece);

            if (compose != null)
            {
                compose.Key = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void Remove(string[] tokens, ref List<Compose> composes)
        {
            string piece = tokens[0];

            Compose compose = composes.FirstOrDefault(x => x.Piece == piece);

            if (compose != null)
            {
                composes.Remove(compose);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void AddCompose(string[] tokens, ref List<Compose> composes, bool wantFeedBack = false)
        {
            string piece = tokens[0];
            string composer = tokens[1];
            string key = tokens[2];

            if (composes.Any(c => c.Piece == piece))
            {
                if (wantFeedBack)
                {
                    Console.WriteLine($"{piece} is already in the collection!");
                }

                return;
            }

            Compose compose = new Compose(piece, composer, key);
            composes.Add(compose);
            if (wantFeedBack)
            {
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }
    }

    class Compose
    {
        public Compose(string piece, string composer, string key)
        {
            this.Piece = piece;
            this.Composer = composer;
            this.Key = key;
        }

        public string Piece { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }

        public override string ToString()
        {
            return $"{this.Piece} -> Composer: {this.Composer}, Key: {this.Key}";
        }
    }
}
