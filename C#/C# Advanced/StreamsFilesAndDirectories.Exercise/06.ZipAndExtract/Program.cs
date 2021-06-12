using System;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\SoftUni\C#", @"D:\SoftUni\C#\Archive\TestArchive.zip");

        }
    }
}
