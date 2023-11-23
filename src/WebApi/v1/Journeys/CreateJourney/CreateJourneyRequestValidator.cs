namespace Example.TripScheduler.WebApi.v1.Journeys.CreateJourney;

public sealed class CreateJourneyRequestValidator : Validator<CreateJourneyRequest>
{
    public CreateJourneyRequestValidator()
    {
        RuleFor(x => x.Origin).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Destination).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CarId).GreaterThan(0);
        RuleFor(x => x.DriverId).GreaterThan(0);
        RuleFor(x => x.DepartureTime).NotEmpty();
    }
    
}