using Example.TripScheduler.Domain.Cars;

namespace Example.TripScheduler.Persistence.Repositories;

internal sealed class CarRepository : ICarRepository
{
    private readonly DbSet<Car> _cars;

    public CarRepository(ApplicationDbContext context)
    {
        _cars = context.Set<Car>();
    }

    public async Task<List<Car>> GetAllAsync(CancellationToken ct = default)
    {
        return await _cars.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Car?> GetByIdAsync(CarId id, CancellationToken ct = default)
    {
        return await _cars.FirstOrDefaultAsync(c => c.Id == id, ct);
    }
}