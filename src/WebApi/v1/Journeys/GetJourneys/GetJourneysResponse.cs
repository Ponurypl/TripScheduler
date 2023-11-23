namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

public sealed record GetJourneysResponse
{
    public List<Journey> Journeys { get; init; } = new();
}