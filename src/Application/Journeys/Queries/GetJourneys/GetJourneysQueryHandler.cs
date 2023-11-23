namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneys;

internal sealed class GetJourneysQueryHandler : IQueryHandler<GetJourneysQuery, List<Journey>>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly IMapper _mapper;

    public GetJourneysQueryHandler(IJourneyRepository journeyRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<Journey>>> Handle(GetJourneysQuery request, CancellationToken cancellationToken)
    {
        var journeys = await _journeyRepository.GetAllAsync(cancellationToken);
        List<Journey> results = new();

        foreach (var item in journeys)
        {
            var journey = _mapper.Map<Journey>(item);

            results.Add(journey);
        }

        return results;
    }
}