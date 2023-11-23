using Example.TripScheduler.Domain.Drivers;

namespace Example.TripScheduler.Persistence.Repositories;

public interface IDriverRepository
{
    Task<List<Driver>> GetAsync(string? name, CancellationToken ct = default);
    Task<Driver?> GetByIdAsync(DriverId id, CancellationToken ct = default);
}