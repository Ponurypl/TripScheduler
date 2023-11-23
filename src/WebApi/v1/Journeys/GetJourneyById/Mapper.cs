namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneyById;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Application.Journeys.Queries.GetJourneyById.Participant, Participant>();
        config.NewConfig<Application.Journeys.Queries.GetJourneyById.Driver, Driver>();
        config.NewConfig<Application.Journeys.Queries.GetJourneyById.Car, Car>();
        config.NewConfig<Application.Journeys.Queries.GetJourneyById.Journey, Journey>();
    }
}