namespace Example.TripScheduler.WebApi.v1.Journeys.CreateJourney;

public sealed record CreateJourneyRequest
{
    public required string Origin { get; init; } = default!;
    public required string Destination { get; init; } = default!;
    public required DateTime DepartureTime { get; init; }
    public required int DriverId { get; init; }
    public required int CarId { get; init; }
}