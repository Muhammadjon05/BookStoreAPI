namespace Book.API.Exceptions;

public class CommentNotFoundException : Exception
{
    public CommentNotFoundException(string message) : base($"With this {message} we could not find comment")
    {

    }

}