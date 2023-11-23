namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Drivers.Genders, Genders>();
        config.NewConfig<Domain.Drivers.Driver, Driver>()
              .Map(d => d.Id, s => s.Id.Value);
    }
}