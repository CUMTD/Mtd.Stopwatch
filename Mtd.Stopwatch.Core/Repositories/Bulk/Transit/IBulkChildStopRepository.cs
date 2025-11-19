using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkChildStopRepository<T_Collection> : IChildStopRepository<T_Collection>, IAsyncBulkWriteable<ChildStop, T_Collection>
	where T_Collection : IEnumerable<ChildStop>
{
}
