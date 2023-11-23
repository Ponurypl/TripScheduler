using Example.TripScheduler.Application.Journeys.Commands.AddParticipant;

namespace Example.TripScheduler.WebApi.v1.Journeys.AddParticipant;

internal sealed class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddParticipantRequest, AddParticipantCommand>();
    }
}