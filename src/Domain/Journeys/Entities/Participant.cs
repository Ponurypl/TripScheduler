namespace Example.TripScheduler.Domain.Journeys;

public sealed class Participant : Entity<ParticipantId>
{
    public ScheduledJourney ScheduledJourney { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ContactInformation ContactInformation { get; private set; } = null!;

#pragma warning disable CS8618, IDE0051
    private Participant(ParticipantId id) : base(id)
    {
        //EF Core ctor
    }
#pragma warning restore

    private Participant(ParticipantId id, ScheduledJourney scheduledJourney, string firstName, 
                        string lastName, ContactInformation contactInformation) : base(id)
    {
        ScheduledJourney = scheduledJourney;
        FirstName = firstName;
        LastName = lastName;
        ContactInformation = contactInformation;
    }

    internal static ErrorOr<Participant> Create(ScheduledJourney scheduledJourney, string firstName, string lastName, string? email, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Error.Validation(nameof(Participant), "First name cannot be empty");
        if (string.IsNullOrWhiteSpace(lastName))
            return Error.Validation(nameof(Participant), "Last name cannot be empty");

        var contactInformation = ContactInformation.Create(email, phoneNumber);
        if (contactInformation.IsError)
        {
            return contactInformation.Errors;
        }
        
        return new Participant(ParticipantId.New(), scheduledJourney, firstName, lastName, contactInformation.Value);
    }
}