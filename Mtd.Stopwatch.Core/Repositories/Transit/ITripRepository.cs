using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface ITripRepository<T_Collection> : IAsyncReadable<Trip, T_Collection>, IAsyncWriteable<Trip, T_Collection>, IAsyncIdentifiable<string, Trip>, IDisposable
	where T_Collection : IEnumerable<Trip>
{
	Task<T_Collection> GetAllWithRoutesAsync(CancellationToken cancellationToken);
}
