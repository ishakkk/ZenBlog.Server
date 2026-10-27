using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ZenBlog.Application.Behaviors;

namespace ZenBlog.Application.Extensions;

public static class ServiceRegistrations
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(
                cfg =>
                {
                    cfg.AddMaps(Assembly.GetExecutingAssembly());
                }
            );


        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


    }
}
