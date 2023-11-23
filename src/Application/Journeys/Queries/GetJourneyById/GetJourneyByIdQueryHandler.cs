using Example.TripScheduler.Domain.Journeys;

namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneyById;

internal sealed class GetJourneyByIdQueryHandler : IQueryHandler<GetJourneyByIdQuery, Journey>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly ICarRepository _carRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public GetJourneyByIdQueryHandler(IJourneyRepository journeyRepository, ICarRepository carRepository,
                                      IDriverRepository driverRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _carRepository = carRepository;
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Journey>> Handle(GetJourneyByIdQuery request, CancellationToken cancellationToken)
    {
        var journey = await _journeyRepository.GetByIdAsync(new ScheduledJourneyId(request.Id), cancellationToken);
        if (journey is null)
        {
            return Error.NotFound();
        }

        var response = _mapper.Map<Journey>(journey);

        var car = await _carRepository.GetByIdAsync(journey.Car, cancellationToken);
        response.Car = _mapper.Map<Car>(car!);

        response.EmptySlots = car!.PassengerSeats - journey.Participants.Count;

        var driver = await _driverRepository.GetByIdAsync(journey.Driver, cancellationToken);
        response.Driver = _mapper.Map<Driver>(driver!);

        return response;
    }
}