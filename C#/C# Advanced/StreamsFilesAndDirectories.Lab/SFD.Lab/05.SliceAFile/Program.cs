using System;
using System.IO;
using System.Threading.Tasks;

namespace _05.SliceAFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            byte countOfPieces = 4;
            byte[] buffer = new byte[4096];
            int totalBytes = 0;

            using (Stream fs = new FileStream("sliceMe.txt", FileMode.Open, FileAccess.Read))
            {
                long pieceSize = (long)Math.Ceiling((decimal)fs.Length / countOfPieces);

                for (int i = 1; i <= countOfPieces; i++)
                {
                    int readBytes = 0;

                    using (FileStream ofs = new FileStream($"Part-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        while (readBytes < pieceSize && totalBytes < fs.Length)
                        {
                            int bytes = await fs.ReadAsync(buffer, 0, buffer.Length);
                            await ofs.WriteAsync(buffer, 0, bytes);
                            readBytes += bytes;
                            totalBytes += bytes;
                        }
                    }
                }

            }
        }
    }
}
