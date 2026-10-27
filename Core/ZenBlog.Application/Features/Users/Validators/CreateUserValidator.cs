using FluentValidation;
using ZenBlog.Application.Features.Users.Commands;

namespace ZenBlog.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name Is Required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name Is Required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name Is Required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Is Required").EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
