namespace ForumApp.Data.Models
{
    using ForumApp.Models;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Constants.DataConstant.Post;

    [Comment("Publishes posts")]
    public class Post
    {
        public Post()
        {
        }
        public Post(PostFormModel postFormModel)
        {
            Title = postFormModel.Title;
            Content = postFormModel.Content;
        }

        [Key]
        [Comment("Posts Identifier")]
        public int Id { get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Posts title")]
        public string? Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Posts content")]
        public string? Content { get; set; }

        [Required]
        [Comment("Marks the post as deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
