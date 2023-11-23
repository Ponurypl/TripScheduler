namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneyById;

public sealed record GetJourneyByIdRequest
{
    public Guid JourneyId { get; init; }
}