namespace Example.TripScheduler.Application.Common.Providers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}