using FluentValidation;
using ZenBlog.Application.Features.Comments.Commands;

namespace ZenBlog.Application.Features.Comments.Validators;

public class CreateCommentValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required");
        RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog is required");
        RuleFor(x => x.Body).NotEmpty().WithMessage("Message Body is required");
    }
}
