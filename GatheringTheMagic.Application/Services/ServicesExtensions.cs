using FluentValidation;
using GatheringTheMagic.Application.ExternalServices;
using GatheringTheMagic.Application.Shared.Behavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GatheringTheMagic.Application.Services;

public static class ServicesExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
