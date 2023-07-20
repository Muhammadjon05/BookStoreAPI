namespace Book.API.Exceptions;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(string message) : base($"With this {message} could not find book")
    {
        
    }
    
}