namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

public sealed record Car
{
    public int Id { get; init; }
    public string Brand { get; init; } = default!;
    public string Model { get; init; } = default!;
}