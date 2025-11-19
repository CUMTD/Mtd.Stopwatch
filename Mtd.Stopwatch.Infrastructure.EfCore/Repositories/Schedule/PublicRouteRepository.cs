using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class PublicRouteRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, PublicRoute>(context), IPublicRouteRepository<IReadOnlyCollection<PublicRoute>>
{
	public async Task<IReadOnlyCollection<PublicRoute>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Where(pr => pr.Active)
			.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}
	public async Task<IReadOnlyCollection<PublicRoute>> GetAllWithStopTimesAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(pr => pr.Routes)
			.ThenInclude(r => r.Trips)
			.ThenInclude(t => t.StopTimes)
			.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}
	public Task<PublicRoute> GetByIdentityWithRouteGroupAsync(string identity, CancellationToken cancellationToken) => Query()
		.Where(pr => pr.Id == identity)
		.Include(pr => pr.PublicRouteGroup)
		.SingleAsync(cancellationToken);
}
