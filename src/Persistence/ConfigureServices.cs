using Example.TripScheduler.Persistence.Options;
using Example.TripScheduler.Persistence.Providers;
using Example.TripScheduler.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.TripScheduler.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringDetails>(configuration.GetSection("Database:Default"));

        services.AddSingleton<IConnectionStringProvider, SqliteConnectionStringProvider>();

        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IJourneyRepository, JourneyRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<ApplicationDbContext>();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}