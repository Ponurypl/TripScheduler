using System.Reflection;

namespace Example.TripScheduler.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiLayerServices(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        TypeAdapterConfig.GlobalSettings.Compile();

        ValidatorOptions.Global.LanguageManager.Enabled = false;

        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();
        
        return services;
    }
}