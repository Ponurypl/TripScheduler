using Example.TripScheduler.Application.Journeys.Queries.GetJourneys;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

public sealed class GetJourneysEndpoint : EndpointWithoutRequest<GetJourneysResponse>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<GetJourneysEndpoint> _logger;

    public GetJourneysEndpoint(IMapper mapper, ISender sender, ILogger<GetJourneysEndpoint> logger)
    {
        _mapper = mapper;
        _sender = sender;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("");
        Group<JourneysEndpointsGroup>();
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _sender.Send(new GetJourneysQuery(), ct);

        if (result.IsError)
        {
            LogDefinitions.UnexpectedError(_logger, result.FirstError.Type, result.FirstError.Code, result.FirstError.Description);
            ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
        }

        var response = new GetJourneysResponse
                       {
                           Journeys = _mapper.Map<List<Journey>>(result.Value)
                       };

        await SendOkAsync(response, ct);
    }
}