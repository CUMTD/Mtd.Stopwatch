using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class RerouteRepository(StopwatchContext context) : AsyncEFIdentifiableRepository<string, Reroute>(context), IRerouteRepository<IReadOnlyCollection<Reroute>>
{
	private static IQueryable<Reroute> ActiveQuery(IQueryable<Reroute> query) => query
		.Where(r => r.StartDate <= DateTime.Now)
		.Where(r => r.EndDate == null || r.EndDate >= DateTime.Now);

	public async Task<IReadOnlyCollection<Reroute>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var result = await ActiveQuery(Query())
			.ToArrayAsync(cancellationToken);

		return result.ToImmutableArray();
	}
	public async Task<IReadOnlyCollection<Reroute>> GetAllActiveWithRoutesAsync(CancellationToken cancellationToken)
	{
		var result = await ActiveQuery(Query())
			.Include(r => r.AffectedRoutes)
			.ThenInclude(ar => ar.Routes)
			.AsSplitQuery()
			.AsNoTrackingWithIdentityResolution()
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return result.ToImmutableArray();
	}
}
