using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IRerouteRepository<T_Collection> : IAsyncReadable<Reroute, T_Collection>, IAsyncWriteable<Reroute, T_Collection>, IAsyncIdentifiable<string, Reroute>, IDisposable
	where T_Collection : IEnumerable<Reroute>
{
	Task<T_Collection> GetAllActiveAsync(CancellationToken cancellationToken);
	Task<T_Collection> GetAllActiveWithRoutesAsync(CancellationToken cancellationToken);
}
