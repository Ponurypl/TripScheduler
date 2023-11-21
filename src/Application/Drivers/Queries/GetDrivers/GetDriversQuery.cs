using Example.TripScheduler.Application.Drivers.Queries.Common;

namespace Example.TripScheduler.Application.Drivers.Queries.GetDrivers;

public sealed record GetDriversQuery : IQuery<List<Driver>>;