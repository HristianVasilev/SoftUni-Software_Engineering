using System;
using System.Text;

namespace _5.HTML
{
    class Program
    {
        private static StringBuilder html;

        static void Main(string[] args)
        {
            html = new StringBuilder();

            string title = Console.ReadLine();
            string content = Console.ReadLine();

            GenerateHtml(title, "h1");
            GenerateHtml(content, "article");

            string comment;
            while ((comment = Console.ReadLine()) != "end of comments")
            {
                GenerateHtml(comment, "div");
            }

            string result = html.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        private static void GenerateHtml(string word, string tag)
        {
            html.AppendLine($"<{tag}>")
                .AppendLine($"    {word}")
                .AppendLine($"</{tag}>");        
        }
    }
}
