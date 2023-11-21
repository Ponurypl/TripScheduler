using Example.TripScheduler.Domain.Cars;

namespace Example.TripScheduler.Persistence.Repositories;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync(CancellationToken ct = default);
}