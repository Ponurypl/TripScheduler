namespace Example.TripScheduler.Application.Journeys.Commands.CreateJourney;

internal sealed class CreateJourneyCommandValidator : AbstractValidator<CreateJourneyCommand>
{
    public CreateJourneyCommandValidator()
    {
        RuleFor(x => x.Origin).NotEmpty();
        RuleFor(x => x.Destination).NotEmpty();
        RuleFor(x => x.DepartureTime).NotEmpty();
        RuleFor(x => x.DriverId).GreaterThan(0);
        RuleFor(x => x.CarId).GreaterThan(0);
    }
}