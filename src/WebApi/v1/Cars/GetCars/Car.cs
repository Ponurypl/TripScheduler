namespace Example.TripScheduler.WebApi.v1.Cars.GetCars;

public sealed record Car
{
    public int Id { get; init; }
    public string Brand { get; init; } = default!;
    public string Model { get; init; } = default!;
    public int ProductionYear { get; init; }
    public int PassengerSeats { get; init; }
}