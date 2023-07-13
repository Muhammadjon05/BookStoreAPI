namespace Book.API.Models;

public class BookAuthorModel
{
    public Guid Id { get; set; }

    public Guid BookId { get; set; }

    public Guid AuthorId { get; set; }
}