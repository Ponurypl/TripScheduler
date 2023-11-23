namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

public sealed record Driver
{
    public int Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public Genders Gender { get; init; }
    public double Rating { get; init; }
    public DateTime DriverLicenseSince { get; init; }
}