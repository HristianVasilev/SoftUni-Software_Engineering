using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Article> collectonOfArticles = new List<Article>();
            byte countOfArticles = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < countOfArticles; i++)
            {
                string[] articleArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string title = articleArgs[0];
                string content = articleArgs[1];
                string author = articleArgs[2];

                Article article = new Article(title, content, author);
                collectonOfArticles.Add(article);
            }

            OrderCollectionBy(ref collectonOfArticles);

            string articles = GetArticles(ref collectonOfArticles);
            Console.WriteLine(articles);
        }

        private static string GetArticles(ref IList<Article> collectonOfArticles)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var article in collectonOfArticles)
            {
                sb.AppendLine(article.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private static void OrderCollectionBy(ref IList<Article> collectonOfArticles)
        {
            string orderCriteria = Console.ReadLine();

            Func<Article, string> order;

            switch (orderCriteria)
            {
                case "title":
                    order = (a) => { return a.Title; };

                    break;
                case "content":
                    order = (a) => { return a.Content; };

                    break;
                case "author":
                    order = (a) => { return a.Author; };

                    break;

                default:
                    throw new InvalidOperationException();
            }

            collectonOfArticles = collectonOfArticles.OrderBy(order).ToList();           
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
