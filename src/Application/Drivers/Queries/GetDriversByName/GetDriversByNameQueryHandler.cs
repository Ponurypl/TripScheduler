using Example.TripScheduler.Application.Drivers.Queries.Common;

namespace Example.TripScheduler.Application.Drivers.Queries.GetDriversByName;

internal sealed class GetDriversByNameQueryHandler : IQueryHandler<GetDriversByNameQuery, List<Driver>>
{
    private readonly IDriverRepository _repository;
    private readonly IMapper _mapper;

    public GetDriversByNameQueryHandler(IDriverRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<Driver>>> Handle(GetDriversByNameQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _repository.GetByNameAsync(request.Name, cancellationToken);
        return _mapper.Map<List<Driver>>(drivers);
    }
}