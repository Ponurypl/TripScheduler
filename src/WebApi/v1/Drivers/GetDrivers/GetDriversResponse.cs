namespace Example.TripScheduler.WebApi.v1.Drivers.GetDrivers;

public sealed record GetDriversResponse
{
    public List<Driver> Drivers { get; init; } = new();
}