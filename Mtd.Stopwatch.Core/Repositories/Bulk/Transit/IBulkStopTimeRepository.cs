using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkStopTimeRepository<T_Collection> : IStopTimeRepository<T_Collection>, IAsyncBulkWriteable<StopTime, T_Collection>
	where T_Collection : IEnumerable<StopTime>
{
}
