using Book.API.Models.CommentModels;
using FluentValidation;

namespace Book.API.Validators;

public class CommentValidator : AbstractValidator<CreateCommentModel>
{
    public CommentValidator()
    {
        RuleFor(i => i.Message).NotNull();
    }
    
}