namespace Example.TripScheduler.WebApi.v1.Journeys.GetJourneys;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Application.Journeys.Queries.GetJourneys.Journey, Journey>();
    }
}