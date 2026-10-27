using FluentValidation;
using ZenBlog.Application.Features.Categories.Commands;

namespace ZenBlog.Application.Features.Categories.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name Is Required")
                                                   .MinimumLength(3).WithMessage("Category Name Must Bet At Least 3 Characters");

            RuleFor(x => x.Id).NotEmpty().WithMessage("Category Id Is Required");
        }
    }
}
