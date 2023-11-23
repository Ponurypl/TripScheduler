using Example.TripScheduler.Persistence.Options;
using Microsoft.Extensions.Options;

namespace Example.TripScheduler.Persistence.Providers;

internal sealed class SqliteConnectionStringProvider : IConnectionStringProvider
{
    private readonly string _connectionString;

    public SqliteConnectionStringProvider(IOptions<ConnectionStringDetails> options)
    {
        _connectionString = $"Data Source={Path.Combine(Directory.GetCurrentDirectory(), options.Value.ConnectionString.TrimEnd(';'))};";
    }

    public string GetConnectionString() => _connectionString;
}