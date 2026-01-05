using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class PublicRouteGroupRepository(StopwatchContext context, ILogger<PublicRouteGroupRepository> logger)
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

		var isChildId = stopId.Contains(':') || stopId.Contains('-');

		logger.LogWarning("Fetching PublicRoutes for StopId {StopId} (isChildId: {IsChildId})", stopId, isChildId);

		// Root the query in PublicRoute so Include is valid
		var query = _dbContext
			.Set<PublicRoute>()
			.AsQueryable()
			.Where(pr => pr.Active);

		logger.LogWarning("Results count before stop filter: {Results}", await query.CountAsync(cancellationToken).ConfigureAwait(false));

		query = query
			.Where(pr => pr
				.Routes
				.SelectMany(r => r.Trips)
				.SelectMany(t => t.StopTimes)
				.Any(st =>
						isChildId
							? st.StopId == stopId
							: st.StopId.StartsWith(stopId + ":")))
			.Include(pr => pr.PublicRouteGroup)
			.ThenInclude(prg => prg.Direction)
			.Include(pr => pr.Daytype)
			.AsSplitQuery();

		var results = await query.ToArrayAsync(cancellationToken).ConfigureAwait(false);

		return results.ToLookup(pr => pr.PublicRouteGroup);

	}
}
