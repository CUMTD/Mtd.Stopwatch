using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkRouteRepository(IRouteRepository<IReadOnlyCollection<Route>> routeRepository, StopwatchContext dbContext) : AsyncBulkEFIdentifiableRepository<string, Route>(dbContext), IBulkRouteRepository<IReadOnlyCollection<Route>>
{
	private readonly IRouteRepository<IReadOnlyCollection<Route>> _routeRepository = routeRepository ?? throw new ArgumentNullException(nameof(routeRepository));

	public Task<IReadOnlyCollection<Route>> GetAllWithDirectionAsync(CancellationToken cancellationToken) => _routeRepository.GetAllWithDirectionAsync(cancellationToken);
}
