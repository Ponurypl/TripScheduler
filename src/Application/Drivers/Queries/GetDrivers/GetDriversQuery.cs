namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

public sealed record GetDriversQuery : IQuery<List<Driver>>
{
    public string? Name { get; init; }
}