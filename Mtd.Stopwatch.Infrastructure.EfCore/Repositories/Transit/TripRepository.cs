using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class TripRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Trip>(context), ITripRepository<IReadOnlyCollection<Trip>>
{
	public async Task<IReadOnlyCollection<Trip>> GetAllWithRoutesAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Include(t => t.Route)
			.ThenInclude(r => r.PublicRoute!)
			.ThenInclude(pr => pr.PublicRouteGroup)
			.ThenInclude(prg => prg.Direction)
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return results.ToImmutableArray();
	}
}
