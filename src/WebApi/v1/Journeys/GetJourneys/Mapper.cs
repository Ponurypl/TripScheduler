namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Application.Journeys.Queries.GetJourneys.Participant, Participant>();
        config.NewConfig<Application.Journeys.Queries.GetJourneys.Driver, Driver>();
        config.NewConfig<Application.Journeys.Queries.GetJourneys.Car, Car>();
        config.NewConfig<Application.Journeys.Queries.GetJourneys.Journey, Journey>();
    }
}