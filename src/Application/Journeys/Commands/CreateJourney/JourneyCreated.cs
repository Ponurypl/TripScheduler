namespace Example.TripScheduler.Application.Journeys.Commands.CreateJourney;

public sealed record JourneyCreated
{
    public Guid Id { get; init; }
}