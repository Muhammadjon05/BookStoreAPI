using Book.API.Models.BookModels;
using FluentValidation;

namespace Book.API.Validators;

public class BookValidator : AbstractValidator<CreateBookModel>
{
    public BookValidator()
    {
        RuleFor(x => x.Title).NotNull();
    }
}
