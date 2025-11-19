using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;


public class ParentStopRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, ParentStop>(context), IParentStopRepository<IReadOnlyCollection<ParentStop>>
{
	public async Task<IReadOnlyCollection<ParentStop>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
		.Where(s => s.Active)
		.ToArrayAsync(cancellationToken);

		return results.ToImmutableArray();
	}

	public async Task<IReadOnlyCollection<ParentStop>> GetAllWithChildStopsAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(ps => ps.ChildStops)
			.ToArrayAsync(cancellationToken);

		return results
			.ToImmutableArray();
	}

	public async Task<IReadOnlyCollection<ParentStop>> GetAllWithStopTimesAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(ps => ps.ChildStops)
			.ThenInclude(ps => ps.StopTimes)
			.ToArrayAsync(cancellationToken);

		return results
			.ToImmutableArray();
	}

	public Task<ParentStop?> GetByIdentityOrDefaultWithChildStopsAsync(string id, CancellationToken cancellationToken) => Query()
		.Where(ps => ps.Id == id)
		.Include(ps => ps.ChildStops)
		.SingleOrDefaultAsync(cancellationToken);

	public Task<ParentStop> GetByIdentityWithChildStopsAsync(string id, CancellationToken cancellationToken) => Query()
		.Where(ps => ps.Id == id)
		.Include(ps => ps.ChildStops)
		.SingleAsync(cancellationToken);
	public async Task<ILookup<PublicRouteGroup, PublicRoute>> GetRoutesServedByStopAsync(string stopId, CancellationToken cancellationToken)
	{
		var publicRoutes = await Query()
			.Where(s => s.Id == stopId)
			.SelectMany(s => s.ChildStops)
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
	public async Task<IReadOnlyCollection<ParentStop>> GetWithoutIStopsAsync(CancellationToken cancellationToken)
	{
		var result = await Query()
		.Where(ps => ps.IsIStop == null)
		.ToListAsync(cancellationToken)
		.ConfigureAwait(false);

		return result
			.ToImmutableArray();
	}
}
