using FluentValidation;
using ZenBlog.Application.Features.SubComments.Commands;

namespace ZenBlog.Application.Features.SubComments.Validators;

public class UpdateSubCommentValidator : AbstractValidator<UpdateSubCommentsCommand>
{
    public UpdateSubCommentValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required");
        RuleFor(x => x.CommentId).NotEmpty().WithMessage("Comment is required");
        RuleFor(x => x.Body).NotEmpty().WithMessage("Body is required")
            .MaximumLength(200).WithMessage("Comment must be 200 characters most");
    }
}
