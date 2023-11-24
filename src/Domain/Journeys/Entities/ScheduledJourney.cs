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
    public int PassengersSeats { get; private set; }
    public IReadOnlyList<Participant> Participants => _participants;

#pragma warning disable CS8618, IDE0051
    private ScheduledJourney(ScheduledJourneyId id) : base(id)
    {
        //EF Core ctor
    }
#pragma warning restore

    private ScheduledJourney(ScheduledJourneyId id, string origin, string destination, DateTime departureTime,
                             DriverId driver, CarId car, int passengersSeats) : base(id)
    {
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        Driver = driver;
        Car = car;
        PassengersSeats = passengersSeats;
    }

    public static ErrorOr<ScheduledJourney> Create(string origin, string destination, DateTime departureTime,
                                                   DriverId driver, CarId car, int passengersSeats)
    {
        if (string.IsNullOrWhiteSpace(origin))
            return Error.Validation(nameof(ScheduledJourney), "Origin cannot be empty");

        if (string.IsNullOrWhiteSpace(destination))
            return Error.Validation(nameof(ScheduledJourney), "Destination cannot be empty");

        if (driver == DriverId.Empty)
            return Error.Validation(nameof(ScheduledJourney), "Driver cannot be empty");

        if (car == CarId.Empty)
            return Error.Validation(nameof(ScheduledJourney), "Car cannot be empty");

        if (passengersSeats <= 0)
            return Error.Validation(nameof(ScheduledJourney), "Car has to have passenger seats");

        return new ScheduledJourney(ScheduledJourneyId.New(), origin, destination, departureTime, driver, car, passengersSeats);
    }

    public ErrorOr<Participant> AddParticipant(string firstName, string lastName, string? email, string? phoneNumber)
    {
        if (Participants.Count == PassengersSeats)
        {
            return Error.Conflict(nameof(ScheduledJourney), "Not enough space in car");
        }

        var participant = Participant.Create(this, firstName, lastName, email, phoneNumber);

        if (participant.IsError)
        {
            return participant.Errors;
        }

        _participants.Add(participant.Value);
        return participant;
    }
}