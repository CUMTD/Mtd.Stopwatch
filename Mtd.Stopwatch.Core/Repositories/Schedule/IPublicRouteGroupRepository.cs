using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Core.Repositories.Schedule;

public interface IPublicRouteGroupRepository<T_Collection> : IAsyncReadable<PublicRouteGroup, T_Collection>, IAsyncWriteable<PublicRouteGroup, T_Collection>, IAsyncIdentifiable<string, PublicRouteGroup>, IDisposable
	where T_Collection : IEnumerable<PublicRouteGroup>
{
	Task<T_Collection> GetAllWithPublicRoutesAsync(CancellationToken cancellationToken, bool includeDirections = false, bool includeDaytypes = false, bool includeRoutes = false);

	Task<PublicRouteGroup> GetByIdentityWithPublicRoutesAsync(string identity, CancellationToken cancellationToken, bool includeDirections = false, bool includeDaytype = false, bool includeRoutes = false);
}
