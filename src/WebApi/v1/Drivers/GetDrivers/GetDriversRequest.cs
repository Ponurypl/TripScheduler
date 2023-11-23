namespace Example.TripScheduler.WebApi.v1.Drivers.GetDrivers;

public sealed record GetDriversRequest
{
    public string? Name { get; init; } 
}