namespace Example.TripScheduler.WebApi.v1.Journeys.AddParticipant;

public sealed class AddParticipantRequestValidator : Validator<AddParticipantRequest>
{
    public AddParticipantRequestValidator()
    {
        RuleFor(x => x.JourneyId).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        
        RuleFor(x => x.Email)
            .NotEmpty()
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