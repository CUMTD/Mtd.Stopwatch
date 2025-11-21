using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class StopTimeRepository(StopwatchContext context)
	: AsyncEFRepository<StopTime>(context), IStopTimeRepository<IReadOnlyCollection<StopTime>>
{
	public async Task<StopTime> GetByIdentityAsync(string tripId, short stopSequence, CancellationToken cancellationToken)
	{
		var result = await GetByIdentityAsync(tripId, stopSequence, cancellationToken)
		.ConfigureAwait(false);

		return result ?? throw new InvalidOperationException($"{tripId},{stopSequence} not found.");
	}

	public async Task<StopTime?> GetByIdentityOrDefaultAsync(string tripId, short stopSequence, CancellationToken cancellationToken)
	{
		var result = await _dbSet
			.FindAsync([tripId, stopSequence], cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		return result;
	}

	public async Task<IReadOnlyCollection<PublicRouteGroup>> GetPublicRouteGroupsByStopId(string stopId, CancellationToken cancellationToken)
	{
		var publicRouteGroups = await _dbSet
			.Where(st => st.StopId == stopId)
			.Where(st => st.Trip != null &&
						 st.Trip.Route != null &&
						 st.Trip.Route.PublicRoute != null &&
						 st.Trip.Route.PublicRoute.PublicRouteGroup != null)
			.Select(st => st.Trip!.Route!.PublicRoute!.PublicRouteGroup!)
			.Include(prg => prg.Direction)
			.Distinct()
			.ToListAsync(cancellationToken)
			.ConfigureAwait(false);

		return publicRouteGroups!;
	}
}
