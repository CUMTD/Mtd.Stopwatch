using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface IRouteRepository<T_Collection> : IAsyncReadable<Route, T_Collection>, IAsyncWriteable<Route, T_Collection>, IAsyncIdentifiable<string, Route>, IDisposable
	where T_Collection : IEnumerable<Route>
{
	Task<T_Collection> GetAllWithDirectionAsync(CancellationToken cancellationToken);
}
