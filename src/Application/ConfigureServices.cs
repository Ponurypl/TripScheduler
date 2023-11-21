using System.Reflection;
using Example.TripScheduler.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Example.TripScheduler.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
                            {
                                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                                cfg.AddOpenBehavior(typeof(UnhandledExceptionBehavior<,>));
                                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                            });

        return services;
    }
}