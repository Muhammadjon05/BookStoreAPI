namespace Book.API.Exceptions;

public class UnRelatedAuhotorsBookException : Exception
{
    public UnRelatedAuhotorsBookException(string message) : base(message)
    {
        
    }
}