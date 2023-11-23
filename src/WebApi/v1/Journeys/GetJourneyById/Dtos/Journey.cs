namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneyById;

public sealed record Journey
{
    public Guid Id { get; init; }
    public string Origin { get; init; } = default!;
    public string Destination { get; init; } = default!;
    public DateTime DepartureTime { get; init; }
    public int EmptySlots { get; init; }
    public Driver Driver { get; internal set; } = null!;
    public Car Car { get; internal set; } = null!;
    public List<Participant> Participants { get; init; } = new();
}