using Example.TripScheduler.Domain.Journeys;

namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneys;

internal sealed class GetJourneysQueryHandler : IQueryHandler<GetJourneysQuery, List<Journey>>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly ICarRepository _carRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public GetJourneysQueryHandler(IJourneyRepository journeyRepository, ICarRepository carRepository,
                                   IDriverRepository driverRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _carRepository = carRepository;
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<Journey>>> Handle(GetJourneysQuery request, CancellationToken cancellationToken)
    {
        var journeys = await _journeyRepository.GetAllAsync(cancellationToken);
        List<Journey> results = new();

        Parallel.ForEach(journeys, BuildJourneyModel);

        return results;

        async void BuildJourneyModel(ScheduledJourney item)
        {
            var journey = _mapper.Map<Journey>(item);

            var car = await _carRepository.GetByIdAsync(item.Car, cancellationToken);
            journey.Car = _mapper.Map<Car>(car);

            var driver = await _driverRepository.GetByIdAsync(item.Driver, cancellationToken);
            journey.Driver = _mapper.Map<Driver>(driver);

            results.Add(journey);
        }
    }
}