namespace ForumApp.Models
{
    using ForumApp.Data.Models;

    public class PostViewModel
    {
        public PostViewModel()
        {
        }
        public PostViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
