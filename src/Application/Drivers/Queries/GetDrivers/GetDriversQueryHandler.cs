using Example.TripScheduler.Application.Drivers.Queries.Common;

namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

internal sealed class GetDriversQueryHandler : IQueryHandler<GetDriversQuery, List<Driver>>
{
    private readonly IDriverRepository _repository;
    private readonly IMapper _mapper;

    public GetDriversQueryHandler(IDriverRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<Driver>>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<Driver>>(drivers);
    }
}