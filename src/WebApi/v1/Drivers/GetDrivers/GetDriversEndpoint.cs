using Example.TripScheduler.Application.Drivers.Queries.GetDrivers;
using Example.TripScheduler.Application.Drivers.Queries.GetDriversByName;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Drivers.GetDrivers;

public sealed class GetDriversEndpoint : Endpoint<GetDriversRequest, GetDriversResponse>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<GetDriversEndpoint> _logger;

    public GetDriversEndpoint(IMapper mapper, ISender sender, ILogger<GetDriversEndpoint> logger)
    {
        _mapper = mapper;
        _sender = sender;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/drivers/"); 
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(GetDriversRequest request, CancellationToken ct)
    {
        var result = request.Name is null
                         ? await _sender.Send(new GetDriversQuery(), ct)
                         : await _sender.Send(new GetDriversByNameQuery { Name = request.Name }, ct);

        if (result.IsError)
        {
            LogDefinitions.UnexpectedError(_logger, result.FirstError.Type, result.FirstError.Code, result.FirstError.Description);
            ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
        }

        var response = new GetDriversResponse
                       {
                           Drivers = _mapper.Map<List<Driver>>(result.Value)
                       };

        await SendOkAsync(response, ct);
    }
}