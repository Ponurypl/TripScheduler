using Example.TripScheduler.Application.Common.Providers;

namespace Example.TripScheduler.Infrastructure.Providers;

internal sealed class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}