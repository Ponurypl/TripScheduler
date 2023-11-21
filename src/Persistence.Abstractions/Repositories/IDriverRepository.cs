using Example.TripScheduler.Domain.Drivers;

namespace Example.TripScheduler.Persistence.Repositories;

public interface IDriverRepository
{
    Task<List<Driver>> GetAllAsync(CancellationToken ct = default);
    Task<List<Driver>> GetByNameAsync(string name, CancellationToken ct = default);
    Task<Driver> GetByIdAsync(DriverId id, CancellationToken ct = default);
}