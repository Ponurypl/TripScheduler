using Example.TripScheduler.Application.Journeys.Queries.GetJourneyById;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneyById;

public sealed class GetJourneyByIdEndpoint : Endpoint<GetJourneyByIdRequest, Journey>
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly ILogger<GetJourneyByIdEndpoint> _logger;

    public GetJourneyByIdEndpoint(ISender sender, IMapper mapper, ILogger<GetJourneyByIdEndpoint> logger)
    {
        _sender = sender;
        _mapper = mapper;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("{JourneyId}");
        Group<JourneysEndpointsGroup>();
        Description(d =>
                    {
                        d.ProducesValidationProblem();
                        d.Produces(StatusCodes.Status404NotFound);
                    });
        Version(1);
    }

    public override async Task HandleAsync(GetJourneyByIdRequest req, CancellationToken ct)
    {
        var result = await _sender.Send(new GetJourneyByIdQuery { Id = req.JourneyId }, ct);

        await result.SwitchFirstAsync(async journey =>
                                      {
                                          await SendOkAsync(_mapper.Map<Journey>(result.Value), ct);
                                      },
                                      async error =>
                                      {
                                          if (error.Type is ErrorType.NotFound)
                                          {
                                              await SendNotFoundAsync(ct);
                                          }
                                          else
                                          {
                                              LogDefinitions.UnexpectedError(_logger, error.Type, error.Code,
                                                                             error.Description);
                                              ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
                                          }

                                      });
    }
}