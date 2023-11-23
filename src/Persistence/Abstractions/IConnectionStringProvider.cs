namespace Example.TripScheduler.Persistence;

internal interface IConnectionStringProvider
{
    string GetConnectionString();
}