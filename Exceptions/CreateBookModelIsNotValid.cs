namespace Book.API.Exceptions;

public class CreateBookModelIsNotValid : Exception
{
    public CreateBookModelIsNotValid(string message) : base(message)
    {
        
    }
    
}