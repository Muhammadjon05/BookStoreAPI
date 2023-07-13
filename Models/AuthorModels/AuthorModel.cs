using Book.API.Models.CommentModels;

namespace Book.API.Models.AuthorModels;

public class AuthorModel
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public virtual List<BookAuthorModel> AuthorBooks { get; set; }
    public virtual List<CommentModel> Comments { get; set; }
}