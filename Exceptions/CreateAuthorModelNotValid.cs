namespace Book.API.Exceptions;

public class CreateAuthorModelNotValid : Exception
{
    public CreateAuthorModelNotValid(string message) : base(message)
    {
        
    }
}