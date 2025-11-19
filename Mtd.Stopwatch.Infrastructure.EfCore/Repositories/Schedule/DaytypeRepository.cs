using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Repositories.Schedule;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Schedule;

public class DaytypeRepository(StopwatchContext context) : AsyncEFIdentifiableRepository<string, Daytype>(context), IDaytypeRepository<IReadOnlyCollection<Daytype>>
{
	public async Task<IReadOnlyCollection<Daytype>> GetAllWithRoutesAsync(CancellationToken cancellationToken)
	{
		var result = await Query()
			.Include(dt => dt.Routes)
			.ThenInclude(r => r.PublicRouteGroup)
			.ThenInclude(prg => prg.PublicRoutes)
			.ToArrayAsync(cancellationToken)
			.ConfigureAwait(false);

		return result.ToImmutableArray();
	}
}
