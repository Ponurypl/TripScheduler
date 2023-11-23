using Example.TripScheduler.Domain.Drivers;

namespace Example.TripScheduler.Persistence.Repositories;

internal sealed class DriverRepository : IDriverRepository
{
    private readonly DbSet<Driver> _drivers;

    public DriverRepository(ApplicationDbContext context)
    {
        _drivers = context.Set<Driver>();
    }

    public async Task<List<Driver>> GetAsync(CancellationToken ct = default)
    {
        return await _drivers.AsNoTracking().ToListAsync(ct);
    }

    public async Task<List<Driver>> GetAsync(string? name, CancellationToken ct = default)
    {
        var query = _drivers.AsNoTracking();
        
        if (name is not null)
        {
            query = query.Where(x => x.LastName == name || x.FirstName == name);
        }

        return await query.ToListAsync(ct);
    }

    public async Task<Driver?> GetByIdAsync(DriverId id, CancellationToken ct = default)
    {
        return await _drivers.FirstOrDefaultAsync(d => d.Id == id, ct);
    }
}