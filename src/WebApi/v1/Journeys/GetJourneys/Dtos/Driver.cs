namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

public sealed record Driver
{
    public int Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public double Rating { get; init; }
}