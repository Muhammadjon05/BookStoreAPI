namespace Book.API.Models.AuthorModels;

public class CreateAuthorModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}