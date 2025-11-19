using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkRouteRepository<T_Collection> : IRouteRepository<T_Collection>, IAsyncBulkWriteable<Route, T_Collection>
	where T_Collection : IEnumerable<Route>
{
}
