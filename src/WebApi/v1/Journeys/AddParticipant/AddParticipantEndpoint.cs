using Example.TripScheduler.Application.Journeys.Commands.AddParticipant;
using Example.TripScheduler.WebApi.Common.Logging;

namespace Example.TripScheduler.WebApi.v1.Journeys.AddParticipant;

public sealed class AddParticipantEndpoint : Endpoint<AddParticipantRequest, AddParticipantResponse>
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ILogger<AddParticipantEndpoint> _logger;

    public AddParticipantEndpoint(IMapper mapper, ISender sender, ILogger<AddParticipantEndpoint> logger)
    {
        _mapper = mapper;
        _sender = sender;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("{JourneyId}/participants");
        Group<JourneysEndpointsGroup>();
        Description(d =>
                    {
                        d.ProducesValidationProblem();
                        d.Produces(StatusCodes.Status409Conflict);
                    });
        Version(1);
    }

    public override async Task HandleAsync(AddParticipantRequest req, CancellationToken ct)
    {
        var result = await _sender.Send(_mapper.Map<AddParticipantCommand>(req), ct);

        await result.SwitchFirstAsync(async participant =>
                                      {
                                          await SendOkAsync(new AddParticipantResponse { Id = participant.Id }, ct);
                                      },
                                      async error =>
                                      {
                                          switch (error.Type)
                                          {
                                              case ErrorType.Validation:
                                                  ThrowError(error.Description);
                                                  break;

                                              case ErrorType.Conflict:
                                                  await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
                                                  break;

                                              default:
                                                  LogDefinitions.UnexpectedError(_logger, error.Type, error.Code, error.Description);
                                                  ThrowError("Unexpected error", StatusCodes.Status500InternalServerError);
                                                  break;
                                          }
                                      });
    }
}