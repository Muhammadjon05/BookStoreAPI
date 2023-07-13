namespace Book.API.Models.CommentModels;

public class CreateCommentModel
{
    public string Message { get; set; }
    
    public Guid BookId { get; set; }
    
    public Guid AuthorId { get; set; }
}