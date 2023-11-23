using System.Text.Json.Serialization;
using Example.TripScheduler.Application;
using Example.TripScheduler.Infrastructure;
using Example.TripScheduler.Persistence;
using Example.TripScheduler.WebApi;
using FastEndpoints.Swagger;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .Enrich.FromLogContext()
             .WriteTo.File("logs/TripScheduler_.log", rollingInterval: RollingInterval.Day)
             .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    var logOutputTemplate = "[{Timestamp:HH:mm:ss} {Level:u4}] {SourceContext}: {Message:lj}{NewLine}{Exception}";
    builder.Host.UseSerilog((context, _, configuration)
                                => configuration
                                   .ReadFrom.Configuration(context.Configuration)
                                   .Enrich.FromLogContext()
                                   .WriteTo.File("logs/TripScheduler_.log", 
                                                 rollingInterval: RollingInterval.Day,
                                                 outputTemplate: logOutputTemplate)
                                   .WriteTo.Console(outputTemplate: logOutputTemplate));

    var services = builder.Services;

    services.AddApplicationLayerServices()
            .AddInfrastructureLayerServices()
            .AddPersistenceLayerServices(builder.Configuration)
            .AddWebApiLayerServices();

    services.AddFastEndpoints()
            .SwaggerDocument(o =>
                             {
                                 o.EnableJWTBearerAuth = false;
                                 o.ShortSchemaNames = true;
                                 o.MaxEndpointVersion = 1;
                                 o.DocumentSettings = s =>
                                                      {
                                                          s.Title = "TripScheduler.WebApi";
                                                          s.Version = "v1";
                                                      };
                                 o.SerializerSettings = s =>
                                                        {
                                                            s.PropertyNamingPolicy = null;
                                                            s.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                                                        };
                             });

    var app = builder.Build();

    app.UseFastEndpoints(c =>
                         {
                             c.Endpoints.ShortNames = true;
                             c.Endpoints.RoutePrefix = "api";

                             c.Versioning.DefaultVersion = 1;
                             c.Versioning.Prefix = "v";
                             c.Versioning.PrependToRoute = true;
                         })
       .UseSwaggerGen();

    if (app.Environment.IsDevelopment())
    {
        await app.Services.InitializeDatabaseAsync();
    }

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application startup fatal error");
}
finally
{
    Log.CloseAndFlush();
}