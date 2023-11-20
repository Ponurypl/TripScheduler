using Example.TripScheduler.Domain.Common.Extensions;

namespace Example.TripScheduler.Domain.Drivers;

public sealed class Driver : AggregateRoot<DriverId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Genders Gender { get; private set; }
    public double Rating { get; private set; }
    public DateTime DriverLicenseSince { get; private set; }

#pragma warning disable CS8618, IDE0051
    private Driver(DriverId id) : base(id)
    {
        //EF Core ctor
    }
#pragma warning restore

    private Driver(DriverId id, string firstName, string lastName, Genders gender, double rating,
                   DateTime driverLicenseSince) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Rating = rating;
        DriverLicenseSince = driverLicenseSince;
    }

    public static ErrorOr<Driver> Create(string firstName, string lastName, Genders gender,
                                         double rating, DateTime driverLicenseSince)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Error.Validation(nameof(Driver), "First name cannot be empty");

        if (string.IsNullOrWhiteSpace(lastName))
            return Error.Validation(nameof(Driver), "Last name cannot be empty");

        if (!gender.IsValidForEnum())
            return Error.Validation(nameof(Driver), "Gender value is invalid");

        if (rating is < 0 or > 5)
            return Error.Validation(nameof(Driver), "Rating must be between 0 and 5");

        if (driverLicenseSince.Year < 1960)
            return Error.Validation(nameof(Driver), "Driver is too old");
        
        return new Driver(DriverId.Empty, firstName, lastName, gender, rating, driverLicenseSince);
    }
}