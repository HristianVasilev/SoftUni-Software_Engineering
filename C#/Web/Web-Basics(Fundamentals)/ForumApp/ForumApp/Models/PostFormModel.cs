namespace ForumApp.Models
{
    using ForumApp.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static ForumApp.Constants.DataConstant.Post;
    using static ForumApp.Constants.DataConstant.Post.ErrorMessage;

    public class PostFormModel
    {
        public PostFormModel()
        {
        }
        public PostFormModel(Post post)
        {
            Title = post.Title;
            Content = post.Content;
        }

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = FieldLength)]
        public string? Title { get; set; }

        [Required(ErrorMessage = FieldRequired)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = FieldLength)]
        public string? Content { get; set; }
    }
}
