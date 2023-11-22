using Example.TripScheduler.Application.Drivers.Queries.Common;

namespace Example.TripScheduler.Application.Drivers.Queries.GetDriversByName;

public sealed record GetDriversByNameQuery : IQuery<List<Driver>>
{
    public required string Name { get; init; } = default!;
}