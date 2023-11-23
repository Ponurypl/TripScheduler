using Example.TripScheduler.Application.Journeys.Commands.CreateJourney;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Journeys.CreateJourney;

public sealed class CreateJourneyEndpoint : Endpoint<CreateJourneyRequest, CreateJourneyResponse>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<CreateJourneyEndpoint> _logger;

    public CreateJourneyEndpoint(IMapper mapper, ISender sender, ILogger<CreateJourneyEndpoint> logger)
    {
        _mapper = mapper;
        _sender = sender;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("");
        Group<JourneysEndpointsGroup>();
        Description(d => d.ProducesValidationProblem());
        Version(1);
    }

    public override async Task HandleAsync(CreateJourneyRequest req, CancellationToken ct)
    {
        var result = await _sender.Send(_mapper.Map<CreateJourneyCommand>(req), ct);

        await result.SwitchFirstAsync(async journey =>
                                      {
                                          await SendOkAsync(new CreateJourneyResponse { Id = journey.Id }, ct);
                                      },
                                      error =>
                                      {
                                          if (error.Type is ErrorType.Validation)
                                          {
                                              ThrowError(error.Description);
                                          }
                                          else
                                          {
                                              LogDefinitions.UnexpectedError(_logger, error.Type, error.Code, error.Description);
                                              ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
                                          }

                                          return Task.CompletedTask;
                                      });



    }
}