namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

internal sealed class GetDriversQueryValidator : AbstractValidator<GetDriversQuery>
{
    public GetDriversQueryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}