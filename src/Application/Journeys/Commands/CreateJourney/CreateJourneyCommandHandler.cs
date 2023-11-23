using Example.TripScheduler.Domain.Cars;
using Example.TripScheduler.Domain.Drivers;
using Example.TripScheduler.Domain.Journeys;
using Example.TripScheduler.Persistence;

namespace Example.TripScheduler.Application.Journeys.Commands.CreateJourney;

internal sealed class CreateJourneyCommandHandler : ICommandHandler<CreateJourneyCommand, JourneyCreated>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly ICarRepository _carRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateJourneyCommandHandler(IJourneyRepository journeyRepository, ICarRepository carRepository,
                                       IDriverRepository driverRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _journeyRepository = journeyRepository;
        _carRepository = carRepository;
        _driverRepository = driverRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<JourneyCreated>> Handle(CreateJourneyCommand request, CancellationToken cancellationToken)
    {
        if (request.DepartureTime <= _dateTimeProvider.UtcNow)
        {
            return Error.Validation(nameof(CreateJourneyCommand), "Departure cannot happen in the past");
        }

        var car = await _carRepository.GetByIdAsync(new CarId(request.CarId), cancellationToken);
        if (car is null)
        {
            return Error.Validation(nameof(CreateJourneyCommand), "Invalid CarId");
        }

        var driver = await _driverRepository.GetByIdAsync(new DriverId(request.DriverId), cancellationToken);
        if (driver is null)
        {
            return Error.Validation(nameof(CreateJourneyCommand), "Invalid DriverId");
        }

        var journey = ScheduledJourney.Create(request.Origin, request.Destination, request.DepartureTime, driver.Id,
                                              car.Id, car.PassengerSeats);
        if (journey.IsError)
        {
            return journey.Errors;
        }

        await _journeyRepository.AddAsync(journey.Value, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new JourneyCreated { Id = journey.Value.Id.Value };
    }
}