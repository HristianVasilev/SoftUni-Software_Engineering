using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Play":
                        Play(ref songs);
                        break;
                    case "Add":
                        string song = string.Join(' ', command.Skip(1));
                        Add(song, ref songs);
                        break;
                    case "Show":
                        Show(ref songs);
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }

        private static void Show(ref Queue<string> songs)
        {
            Console.WriteLine(string.Join(", ", songs));
        }

        private static void Add(string song, ref Queue<string> songs)
        {
            if (songs.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
                return;
            }

            songs.Enqueue(song);
        }

        private static void Play(ref Queue<string> songs)
        {
            songs.Dequeue();
        }
    }
}
