namespace Book.API.Exceptions;

public class CreateCommentModelIsNotValid : Exception
{
    public CreateCommentModelIsNotValid(string message) : base(message)
    {
        
    }
    
}