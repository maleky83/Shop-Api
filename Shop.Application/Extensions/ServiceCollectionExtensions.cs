using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        Assembly applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddAutoMapper(cfg => { }, applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
    }
}
