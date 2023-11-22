namespace Example.TripScheduler.Application.Journeys.Commands.AddParticipant;

internal sealed class AddParticipantCommandValidator : AbstractValidator<AddParticipantCommand>
{
    public AddParticipantCommandValidator()
    {
        RuleFor(x => x.JourneyId).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => x.Email is not null || x.Phone is null)
            .WithMessage("At least one contact detail (email or phone number) has to be valid.");
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(15)
            .When(x => x.Phone is not null || x.Email is null)
            .WithMessage("At least one contact detail (email or phone number) has to be valid.");
    }
    
}