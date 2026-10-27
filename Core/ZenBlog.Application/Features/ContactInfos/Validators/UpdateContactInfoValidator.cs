using FluentValidation;
using ZenBlog.Application.Features.ContactInfos.Commands;

namespace ZenBlog.Application.Features.ContactInfos.Validators;

public class UpdateContactInfoValidator : AbstractValidator<UpdateContactInfoCommand>
{
    public UpdateContactInfoValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.");
        RuleFor(x => x.MapUrl)
            .NotEmpty().WithMessage("Map URL is required.");
    }
}
