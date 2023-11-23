using Example.TripScheduler.Application.Journeys.Commands.CreateJourney;

namespace Example.TripScheduler.WebApi.v1.Journeys.CreateJourney;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateJourneyRequest, CreateJourneyCommand>();
    }
}