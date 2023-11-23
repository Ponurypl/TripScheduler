namespace Example.TripScheduler.Application.Cars.Queries.GetCars;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Cars.Car, Car>()
              .Map(d => d.Id, s => s.Id.Value);
    }
}