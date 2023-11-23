namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneyById;

public sealed record GetJourneyByIdQuery : IQuery<Journey>
{
    public required Guid Id { get; init; }
}