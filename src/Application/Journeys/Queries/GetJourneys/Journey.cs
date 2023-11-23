namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneys;

public sealed record Journey
{
    public Guid Id { get; init; }
    public string Origin { get; init; } = default!;
    public string Destination { get; init; } = default!;
    public DateTime DepartureTime { get; init; }
    public int EmptySlots { get; internal set; }
}