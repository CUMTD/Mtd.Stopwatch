using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkTripRepository<T_Collection> : ITripRepository<T_Collection>, IAsyncBulkWriteable<Trip, T_Collection>
	where T_Collection : IEnumerable<Trip>
{
	Task TruncateTripToCalendarDateBridgeTable(CancellationToken cancellationToken);
}
