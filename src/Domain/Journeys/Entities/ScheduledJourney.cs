using Example.TripScheduler.Domain.Cars;
using Example.TripScheduler.Domain.Drivers;

namespace Example.TripScheduler.Domain.Journeys;

public sealed class ScheduledJourney : AggregateRoot<ScheduledJourneyId>
{
    private readonly List<Participant> _participants = new();

    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DriverId Driver { get; private set; }
    public CarId Car { get; private set; }
    public IReadOnlyList<Participant> Participants => _participants;

#pragma warning disable CS8618, IDE0051
    public ScheduledJourney(ScheduledJourneyId id) : base(id)
    {
        //EF Core ctor
    }
#pragma warning restore

    private ScheduledJourney(ScheduledJourneyId id, string origin, string destination, DateTime departureTime,
                             DriverId driver, CarId car) : base(id)
    {
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        Driver = driver;
        Car = car;
    }

    public static ErrorOr<ScheduledJourney> Create(string origin, string destination, DateTime departureTime,
                                                   DriverId driver, CarId car)
    {
        if (string.IsNullOrWhiteSpace(origin))
            return Error.Validation(nameof(ScheduledJourney), "Origin cannot be empty");

        if (string.IsNullOrWhiteSpace(destination))
            return Error.Validation(nameof(ScheduledJourney), "Destination cannot be empty");

        if (driver == DriverId.Empty)
            return Error.Validation(nameof(ScheduledJourney), "Driver cannot be empty");

        if (car == CarId.Empty)
            return Error.Validation(nameof(ScheduledJourney), "Car cannot be empty");

        return new ScheduledJourney(ScheduledJourneyId.New(), origin, destination, departureTime, driver, car);
    }

    public ErrorOr<Participant> AddParticipant(string firstName, string lastName, string? email, string? phoneNumber)
    {
        var participant = Participant.Create(firstName, lastName, email, phoneNumber);

        if (participant.IsError)
        {
            return participant.Errors;
        }

        _participants.Add(participant.Value);
        return participant;
    }
}