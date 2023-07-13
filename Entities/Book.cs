using System.ComponentModel.DataAnnotations;

namespace Book.API.Entities;
public class Book
{
    [Key]
    public Guid BookId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }

    public string? BookPhotoUrl { get; set; }
    public required string BookFileUrl { get; set; }

    public virtual List<BookAuthor> AuthorBooks { get; set; }
    public virtual List<Comment> Comments { get; set; }
}

