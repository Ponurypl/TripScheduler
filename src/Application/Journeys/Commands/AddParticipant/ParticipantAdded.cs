namespace Example.TripScheduler.Application.Journeys.Commands.AddParticipant;

public sealed record ParticipantAdded
{
    public Guid Id { get; init; }
}