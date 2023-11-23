using Example.TripScheduler.Domain.Drivers;

namespace Example.TripScheduler.Persistence.Repositories;

internal sealed class DriverRepository : IDriverRepository
{
    private readonly DbSet<Driver> _drivers;

    public DriverRepository(ApplicationDbContext context)
    {
        _drivers = context.Set<Driver>();
    }

    public async Task<List<Driver>> GetAllAsync(CancellationToken ct = default)
    {
        return await _drivers.AsNoTracking().ToListAsync(ct);
    }

    public async Task<List<Driver>> GetByNameAsync(string name, CancellationToken ct = default)
    {
        return await _drivers.Where(d => d.FirstName == name || d.LastName == name).ToListAsync(ct);
    }

    public async Task<Driver?> GetByIdAsync(DriverId id, CancellationToken ct = default)
    {
        return await _drivers.FirstOrDefaultAsync(d => d.Id == id, ct);
    }
}