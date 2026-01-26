using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class PublicRouteGroupRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, PublicRouteGroup>(context), IPublicRouteGroupRepository<IReadOnlyCollection<PublicRouteGroup>>
{
	public async Task<IReadOnlyCollection<PublicRouteGroup>> GetAllWithPublicRoutesAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(prg => prg.PublicRoutes)
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return results.ToImmutableArray();
	}

	public async Task<IReadOnlyCollection<PublicRouteGroup>> GetAllWithPublicRoutesAsync(CancellationToken cancellationToken, bool includeDirections = false, bool includeDaytypes = false, bool includeRoutes = false)
	{
		var query = Query();

		if (includeDirections)
		{
			query = query.Include(prg => prg.Direction);
		}

		query = includeDaytypes
			? query
				.Include(prg => prg.PublicRoutes)
				.ThenInclude(pr => pr.Daytype)
			: query.Include(prg => prg.PublicRoutes);

		if (includeRoutes)
		{
			query = query.Include(prg => prg.PublicRoutes.Select(pr => pr.Routes));
		}

		var results = await query
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return results.ToImmutableArray();
	}
	public Task<PublicRouteGroup> GetByIdentityWithPublicRoutesAsync(string identity, CancellationToken cancellationToken, bool includeDirections = false, bool includeDaytype = false, bool includeRoutes = false)
	{
		var query = Query()
			.Where(prg => prg.Id == identity);

		if (includeDirections)
		{
			query = query.Include(prg => prg.Direction);
		}

		query = includeDaytype
			? query
				.Include(prg => prg.PublicRoutes)
				.ThenInclude(pr => pr.Daytype)
			: query.Include(prg => prg.PublicRoutes);

		if (includeRoutes)
		{
			query = query.Include(prg => prg.PublicRoutes.Select(pr => pr.Routes));
		}

		return query.SingleAsync(cancellationToken);
	}

	public async Task<ILookup<PublicRouteGroup, PublicRoute>> GetPublicRoutesForStopIdAsync(string stopId, CancellationToken cancellationToken)
	{
		ArgumentException.ThrowIfNullOrEmpty(stopId);

		var stopQuery = stopId.Contains(':') || stopId.Contains('-')
			? _dbContext
				.Set<Core.Entities.Transit.ChildStop>()
				.Where(cs => cs.Id == stopId)
			: _dbContext
				.Set<Core.Entities.Transit.ChildStop>()
				.Where(cs => cs.ParentStopId == stopId);

		var publicRouteIds = await stopQuery
			.SelectMany(cs => cs.StopTimes)
			.Select(st => st.Trip.Route.PublicRoute!.Id)
			.Where(prId => prId != null)
			.Distinct()
			.ToArrayAsync(cancellationToken);

		var result = await _dbContext
			.Set<PublicRoute>()
			.Where(pr => publicRouteIds.Contains(pr.Id) && pr.Active)
			.Include(pr => pr.PublicRouteGroup)
			.ThenInclude(prg => prg.Direction)
			.Include(pr => pr.Daytype)
			.ToArrayAsync(cancellationToken);

		return result.ToLookup(pr => pr.PublicRouteGroup);
	}
}
