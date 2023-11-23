namespace Example.TripScheduler.WebApi.v1.Cars.GetCars;

public sealed record GetCarsResponse
{
    public List<Car> Cars { get; init; } = new();
}