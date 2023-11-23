namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneys;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Journeys.ScheduledJourney, Journey>()
              .Map(d => d.Id, s => s.Id.Value)
              .Map(d => d.EmptySlots, s => s.PassengersSeats - s.Participants.Count);
    }
}