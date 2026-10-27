using FluentValidation;
using ZenBlog.Application.Features.Messages.Commands;

namespace ZenBlog.Application.Features.Messages.Validators
{
    public class UpdateMessageValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage("Name is required.")
              .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .Length(2, 100).WithMessage("Subject must be between 2 and 100 characters.");
            RuleFor(x => x.MessageBody)
                .NotEmpty().WithMessage("Message is required.")
                .Length(2, 500).WithMessage("Message must be between 2 and 500 characters.");
        }
    }
}
