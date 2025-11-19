using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class ChildStopRepository(StopwatchContext context) : AsyncEFIdentifiableRepository<string, ChildStop>(context), IChildStopRepository<IReadOnlyCollection<ChildStop>>
{

	public async Task<IReadOnlyCollection<ChildStop>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
		.Where(s => s.Active)
		.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}

	public async Task<IReadOnlyCollection<ChildStop>> GetAllWithParentAsync(CancellationToken cancellationToken)
	{
		var result = await Query()
			.Include(cs => cs.ParentStop)
			.ToArrayAsync(cancellationToken);
		return result.ToImmutableArray();
	}
	public async Task<IReadOnlyCollection<ChildStop>> GetAllWithStopTimesAsync(CancellationToken cancellationToken)
	{
		var result = await Query()
			.Include(cs => cs.ParentStop)
			.Include(cs => cs.StopTimes)
			.ToArrayAsync(cancellationToken);
		return result.ToImmutableArray();
	}
	public async Task<ILookup<PublicRouteGroup, PublicRoute>> GetRoutesServedByStopAsync(string stopId, CancellationToken cancellationToken)
	{
		var publicRoutes = await Query()
			.Where(s => s.Id == stopId)
			.SelectMany(cs => cs.StopTimes)
			.Select(st => st.Trip)
			.Select(t => t.Route)
			.Select(r => r.PublicRoute!)
			.Include(r => r.PublicRouteGroup)
			.Distinct()
			.ToDictionaryAsync(pr => pr.PublicRouteGroup, cancellationToken)
			.ConfigureAwait(false);

		return publicRoutes
			.ToLookup(pair => pair.Key, pair => pair.Value);
	}
}
