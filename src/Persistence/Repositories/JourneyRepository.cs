using Example.TripScheduler.Domain.Journeys;

namespace Example.TripScheduler.Persistence.Repositories;

internal sealed class JourneyRepository : IJourneyRepository
{
    private readonly DbSet<ScheduledJourney> _journeys;

    public JourneyRepository(ApplicationDbContext context)
    {
        _journeys = context.Set<ScheduledJourney>();
    }

    public async Task<List<ScheduledJourney>> GetAllAsync(CancellationToken ct = default)
    {
        return await _journeys.Include(x => x.Participants).AsNoTracking().ToListAsync(ct);
    }

    public async Task<ScheduledJourney?> GetByIdAsync(ScheduledJourneyId id, CancellationToken ct = default)
    {
        return await _journeys.Include(x => x.Participants).SingleOrDefaultAsync(j => j.Id == id, ct);
    }

    public async Task AddAsync(ScheduledJourney journey, CancellationToken ct = default)
    {
        await _journeys.AddAsync(journey, ct);
    }
}