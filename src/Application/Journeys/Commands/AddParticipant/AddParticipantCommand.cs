namespace Example.TripScheduler.Application.Journeys.Commands.AddParticipant;

public sealed record AddParticipantCommand : ICommand<ParticipantAdded>
{
    public required Guid JourneyId { get; init; }
    public required string FirstName { get; init; } = default!;
    public required string LastName { get; init; } = default!;
    public string? Email { get; init; }
    public string? Phone { get; init; }
}