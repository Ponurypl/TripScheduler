using Example.TripScheduler.Domain.Journeys;

namespace Example.TripScheduler.Persistence.Repositories;

public interface IJourneyRepository
{
    Task<List<ScheduledJourney>> GetAllAsync(CancellationToken ct = default);
}