using System.ComponentModel.DataAnnotations;

namespace Book.API.Entities;

public class Author
{
    [Key]
    public Guid Id { get; set; }    
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public virtual List<BookAuthor> AuthorBooks { get; set; }
    public virtual List<Comment> Comments { get; set; }

}
