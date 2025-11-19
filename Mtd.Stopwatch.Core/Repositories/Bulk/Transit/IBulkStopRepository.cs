using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkStopRepository<T, T_Collection> : IStopRepository<T, T_Collection>, IAsyncBulkWriteable<Stop, T_Collection>
	where T : Stop
	where T_Collection : IEnumerable<T>
{
}
