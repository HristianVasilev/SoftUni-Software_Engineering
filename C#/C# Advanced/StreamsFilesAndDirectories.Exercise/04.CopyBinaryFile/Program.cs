using System;
using System.IO;
using System.Threading.Tasks;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int BufferSize = 4096;

            using (FileStream reader = new FileStream("./copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../copied.png", FileMode.Create))
                {
                    while (reader.CanRead)
                    {
                        byte[] buffer = new byte[BufferSize];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
