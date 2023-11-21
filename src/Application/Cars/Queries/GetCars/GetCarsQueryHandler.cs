namespace Example.TripScheduler.Application.Cars.Queries.GetCars;

internal sealed class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, List<Car>>
{
    private readonly ICarRepository _repository;
    private readonly IMapper _mapper;

    public GetCarsQueryHandler(ICarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<Car>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<Car>>(cars);
    }
}