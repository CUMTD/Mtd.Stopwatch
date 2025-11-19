using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IPublicRouteRepository<T_Collection> : IAsyncReadable<PublicRoute, T_Collection>, IAsyncWriteable<PublicRoute, T_Collection>, IAsyncIdentifiable<string, PublicRoute>, IDisposable
	where T_Collection : IEnumerable<PublicRoute>
{
	Task<T_Collection> GetAllWithStopTimesAsync(CancellationToken cancellationToken);
	Task<T_Collection> GetAllActiveAsync(CancellationToken cancellationToken);
	Task<PublicRoute> GetByIdentityWithRouteGroupAsync(string identity, CancellationToken cancellationToken);
}
