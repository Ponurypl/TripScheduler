namespace Example.TripScheduler.Application.Drivers.Queries.GetDriversByName;

internal sealed class GetDriversByNameQueryValidator : AbstractValidator<GetDriversByNameQuery>
{
    public GetDriversByNameQueryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}