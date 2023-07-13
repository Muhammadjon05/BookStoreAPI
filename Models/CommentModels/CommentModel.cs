namespace Book.API.Models.CommentModels;

public class CommentModel
{
    public Guid Id { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; } 

    public Guid BookId { get; set; }

    public Guid AuthorId { get; set; }
}