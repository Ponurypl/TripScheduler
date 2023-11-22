namespace Example.TripScheduler.Domain.Journeys;

public sealed class ContactInformation : ValueObject
{
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }

#pragma warning disable CS8618, IDE0051
    private ContactInformation()
    {
        //EF Core ctor
    }
#pragma warning restore

    private ContactInformation(string? email, string? phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public static ErrorOr<ContactInformation> Create(string? email, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            return Error.Validation(nameof(ContactInformation), "Email and phone number cannot be both empty");

        return new ContactInformation(email, phoneNumber);
    }

    protected override IEnumerable<object?> GetAtomicValues()
    {
        yield return Email;
        yield return PhoneNumber;
    }
}