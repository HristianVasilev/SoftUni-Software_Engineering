using System;
using System.Linq;

namespace _3.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            string[] file = filePath.Split("\\", StringSplitOptions.RemoveEmptyEntries).Last().Split('.',StringSplitOptions.RemoveEmptyEntries);

            string fileName = file[0];
            string fileExtension = file[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
