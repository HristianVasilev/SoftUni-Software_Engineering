using System;
using System.Linq;

namespace _3.Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            Song[] songs = new Song[numberOfSongs];

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songArgs = Console.ReadLine().Split('_', StringSplitOptions.RemoveEmptyEntries);

                string typeList = songArgs[0];
                string name = songArgs[1];
                string time = songArgs[2];

                Song currentSong = new Song(typeList, name, time);
                songs[i] = currentSong;
            }

            string printTypeList = Console.ReadLine();

            Song[] outputCollection;

            if (printTypeList == "all")
            {
                outputCollection = songs; 
            }
            else
            {
                outputCollection = songs.Where(x => x.TypeList.Equals(printTypeList)).ToArray();
            }

            Console.WriteLine(string.Join(Environment.NewLine, outputCollection.Select(x => x.Name)));
        }
    }

    class Song
    {
        public Song(string typeList, string name, string time)
        {
            this.TypeList = typeList;
            this.Name = name;
            this.Time = time;
        }

        public string TypeList { get; private set; }
        public string Name { get; private set; }
        public string Time { get; private set; }
    }
}
