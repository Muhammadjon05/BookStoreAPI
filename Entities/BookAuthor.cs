using System.ComponentModel.DataAnnotations;

namespace Book.API.Entities;

public class BookAuthor
{
    [Key]
    public Guid Id { get; set; }

    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }

    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }
}
