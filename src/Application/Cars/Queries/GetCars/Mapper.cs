using Example.TripScheduler.Domain.Cars;

namespace Example.TripScheduler.Application.Cars.Queries.GetCars;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Car, CarDto>();
    }
}