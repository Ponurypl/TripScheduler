namespace Example.TripScheduler.WebApi.v1.Drivers.GetDrivers;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Application.Drivers.Queries.Common.Driver, Driver>();
        config.NewConfig<Application.Drivers.Queries.Common.Genders, Genders>();
    }
}