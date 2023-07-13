using Book.API.Models.CommentModels;

namespace Book.API.Models.BookModels;

public class BookModel
{
    public Guid BookId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }

    public string? BookPhotoUrl { get; set; }
    public required string BookFileUrl { get; set; }

    public virtual List<BookAuthorModel> AuthorBooks { get; set; }
    public virtual List<CommentModel> Comments { get; set; }

}