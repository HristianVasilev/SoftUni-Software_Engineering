namespace ForumApp.Data.Configure
{
    using ForumApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Text.Json;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            IList<Post> posts = GetPosts();
            builder.HasData(posts);
        }

        private IList<Post> GetPosts()
        {
            //var path = Path.Combine("bin", "Debug", "net6.0", "Data", "Configure", "seedPosts.json");
            //string text = File.ReadAllText(path);
            //IList<Post>? posts = JsonSerializer.Deserialize<IList<Post>>(text);
            IList<Post>? posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My first post",
                    Content = "My first post will be about performing CRUD operations in MVC. That will be fun!"
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second post",
                    Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
                },
                new Post()
                {
                    Id = 3,
                    Title = "My third post",
                    Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
                }
            };
            return posts != null ? posts : new List<Post>();
        }
    }
}
