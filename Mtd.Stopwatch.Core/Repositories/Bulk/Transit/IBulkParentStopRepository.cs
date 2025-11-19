using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkParentStopRepository<T_Collection> : IParentStopRepository<T_Collection>, IAsyncBulkWriteable<ParentStop, T_Collection>
	where T_Collection : IEnumerable<ParentStop>
{
}
