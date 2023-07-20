using Book.API.Models.AuthorModels;
using FluentValidation;

namespace Book.API.Validators;

public class AuthorValidator : AbstractValidator<CreateAuthorModel>
{
    public AuthorValidator()
    {
        RuleFor(i => i.Password).NotNull().Length(5, 18);
        RuleFor(i => i.Firstname).NotNull().Length(3, 15);
    }
}