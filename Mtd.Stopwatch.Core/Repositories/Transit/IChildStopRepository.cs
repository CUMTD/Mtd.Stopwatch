using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IChildStopRepository<T_Collection> : IStopRepository<ChildStop, T_Collection>, IAsyncReadable<ChildStop, T_Collection>, IAsyncWriteable<ChildStop, T_Collection>, IAsyncIdentifiable<string, ChildStop>, IDisposable
	where T_Collection : IEnumerable<ChildStop>
{
	Task<T_Collection> GetAllWithParentAsync(CancellationToken cancellationToken);
}
