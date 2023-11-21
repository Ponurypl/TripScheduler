namespace Example.TripScheduler.Application.Drivers.Queries.Common;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Drivers.Genders, Genders>();
        config.NewConfig<Domain.Drivers.Driver, Driver>();
    }
}