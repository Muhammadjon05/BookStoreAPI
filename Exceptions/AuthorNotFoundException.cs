namespace Book.API.Exceptions;

public class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException(string message) : base($"With this {message} we could not find an author")
    {
        
    }
}