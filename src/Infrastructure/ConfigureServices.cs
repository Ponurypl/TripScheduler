using Example.TripScheduler.Application.Common.Providers;
using Example.TripScheduler.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Example.TripScheduler.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }
}