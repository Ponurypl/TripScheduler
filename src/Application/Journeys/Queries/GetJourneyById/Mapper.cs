namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneyById;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Journeys.Participant, Participant>()
              .Map(d => d.Id, s => s.Id.Value)
              .Map(d => d.Email, s => s.ContactInformation.Email)
              .Map(d => d.PhoneNumber, s => s.ContactInformation.PhoneNumber);

        config.NewConfig<Domain.Journeys.ScheduledJourney, Journey>()
              .Map(d => d.Id, s => s.Id.Value)
              .Map(d => d.EmptySlots, s => s.PassengersSeats - s.Participants.Count)
              .Ignore(d => d.Driver)
              .Ignore(d => d.Car);

        config.NewConfig<Domain.Cars.Car, Car>()
              .Map(d => d.Id, s => s.Id.Value);

        config.NewConfig<Domain.Drivers.Driver, Driver>()
              .Map(d => d.Id, s => s.Id.Value);
    }
}