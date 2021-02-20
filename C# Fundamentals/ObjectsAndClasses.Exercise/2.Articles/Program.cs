using System;

namespace _2.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = articleArgs[0];
            string content = articleArgs[1];
            string author = articleArgs[2];

            Article article = new Article(title, content, author);

            byte countOfCommands = byte.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];
                string newArgument = commandArgs[1].TrimStart().TrimEnd();

                switch (command)
                {
                    case "Edit":

                        article.Edit(newArgument);

                        break;
                    case "ChangeAuthor":

                        article.ChangeAuthor(newArgument);

                        break;
                    case "Rename":

                        article.Rename(newArgument);

                        break;

                    default:
                        throw new InvalidOperationException("No suck command!");
                }
            }

            string articleInformation = article.ToString();
            Console.WriteLine(articleInformation);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; private set; }
        public string Content { get; private set; }
        public string Author { get; private set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
