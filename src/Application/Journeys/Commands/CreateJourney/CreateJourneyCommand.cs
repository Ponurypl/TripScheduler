namespace Example.TripScheduler.Application.Journeys.Commands.CreateJourney;

public sealed record CreateJourneyCommand : ICommand<JourneyCreated>
{
    public required string Origin { get; init; } = default!;
    public required string Destination { get; init; } = default!;
    public required DateTime DepartureTime { get; init; }
    public required int DriverId { get; init; }
    public required int CarId { get; init; }
}