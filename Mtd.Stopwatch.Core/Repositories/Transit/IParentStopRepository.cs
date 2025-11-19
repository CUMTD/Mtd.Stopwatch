using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IParentStopRepository<T_Collection> : IStopRepository<ParentStop, T_Collection>, IAsyncReadable<ParentStop, T_Collection>, IAsyncWriteable<ParentStop, T_Collection>, IAsyncIdentifiable<string, ParentStop>, IDisposable
	where T_Collection : IEnumerable<ParentStop>
{
	Task<ParentStop> GetByIdentityWithChildStopsAsync(string id, CancellationToken cancellationToken);

	Task<ParentStop?> GetByIdentityOrDefaultWithChildStopsAsync(string id, CancellationToken cancellationToken);

	Task<T_Collection> GetWithoutIStopsAsync(CancellationToken cancellationToken);

	Task<T_Collection> GetAllWithChildStopsAsync(CancellationToken cancellationToken);
}
