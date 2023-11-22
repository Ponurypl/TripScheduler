using Example.TripScheduler.Domain.Journeys;

namespace Example.TripScheduler.Persistence.Repositories;

public interface IJourneyRepository
{
    Task<List<ScheduledJourney>> GetAllAsync(CancellationToken ct = default);
    Task<ScheduledJourney?> GetByIdAsync(ScheduledJourneyId id, CancellationToken ct = default);
    void Add(ScheduledJourney journey);
}