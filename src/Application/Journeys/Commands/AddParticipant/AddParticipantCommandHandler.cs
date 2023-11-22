using Example.TripScheduler.Domain.Journeys;
using Example.TripScheduler.Persistence;

namespace Example.TripScheduler.Application.Journeys.Commands.AddParticipant;

internal sealed class AddParticipantCommandHandler : ICommandHandler<AddParticipantCommand, ParticipantAdded>
{
    private readonly IJourneyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddParticipantCommandHandler(IJourneyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<ParticipantAdded>> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
    {
        var journey = await _repository.GetByIdAsync(new ScheduledJourneyId(request.JourneyId), cancellationToken);
        
        if (journey is null) return Error.Validation(nameof(AddParticipantCommand), "Invalid JourneyId");

        var participant = journey.AddParticipant(request.FirstName, request.LastName, request.Email, request.Phone);
        if (participant.IsError)
        {
            return participant.Errors;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ParticipantAdded { Id = participant.Value.Id.Value };
    }
}