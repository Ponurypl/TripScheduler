namespace Example.TripScheduler.WebApi.v1.Cars.GetCars;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Application.Cars.Queries.GetCars.Car, Car>();
    }
}