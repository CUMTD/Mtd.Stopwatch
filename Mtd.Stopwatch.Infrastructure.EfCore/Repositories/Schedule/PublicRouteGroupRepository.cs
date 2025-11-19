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
}
