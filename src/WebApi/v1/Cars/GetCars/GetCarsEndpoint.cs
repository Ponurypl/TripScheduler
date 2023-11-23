using Example.TripScheduler.Application.Cars.Queries.GetCars;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Cars.GetCars;

public sealed class GetCarsEndpoint : EndpointWithoutRequest<GetCarsResponse>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<GetCarsEndpoint> _logger;

    public GetCarsEndpoint(ISender sender, IMapper mapper, ILogger<GetCarsEndpoint> logger)
    {
        _sender = sender;
        _mapper = mapper;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/cars");
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _sender.Send(new GetCarsQuery(), ct);

        if (result.IsError)
        {
            LogDefinitions.UnexpectedError(_logger, result.FirstError.Type, result.FirstError.Code, result.FirstError.Description);
            ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
        }

        var response = new GetCarsResponse
                       {
                           Cars = _mapper.Map<List<Car>>(result.Value)
                       };

        await SendOkAsync(response, ct);
    }
}