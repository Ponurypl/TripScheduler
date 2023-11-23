namespace Example.TripScheduler.WebApi.v1.Journeys.AddParticipant;

public sealed record AddParticipantRequest
{
    public Guid JourneyId { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string? Email { get; init; }
    public string? Phone { get; init; }
}