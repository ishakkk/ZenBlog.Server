using FluentValidation;
using MediatR;

namespace ZenBlog.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(
                        _validators.Select(x => x.ValidateAsync(context, cancellationToken))
                    );
                var failures = validationResult.Where(result => result is not null)
                    .SelectMany(x => x.Errors).ToList();


                if (failures.Any())
                {
                    var errorDetails = failures.GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key,
                         x => x.Select(x => x.ErrorMessage).ToArray()
                        ).ToList();

                    throw new ValidationException(failures);
                }
            }

            return await next(cancellationToken);
        }
    }
}
