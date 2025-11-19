using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IDaytypeRepository<T_Collection> : IAsyncReadable<Daytype, T_Collection>, IAsyncWriteable<Daytype, T_Collection>, IAsyncIdentifiable<string, Daytype>, IDisposable
	where T_Collection : IEnumerable<Daytype>
{
	Task<T_Collection> GetAllWithRoutesAsync(CancellationToken cancellationToken);
}
