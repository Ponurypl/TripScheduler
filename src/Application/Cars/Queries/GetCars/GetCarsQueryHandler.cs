namespace Example.TripScheduler.Application.Cars.Queries.GetCars;

public sealed class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, List<CarDto>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarsQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<CarDto>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CarDto>>(cars);
    }
}