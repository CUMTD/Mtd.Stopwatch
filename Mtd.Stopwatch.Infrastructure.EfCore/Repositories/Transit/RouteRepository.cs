using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class RouteRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Route>(context), IRouteRepository<IReadOnlyCollection<Route>>
{
	public async Task<IReadOnlyCollection<Route>> GetAllWithDirectionAsync(CancellationToken cancellationToken)
	{
		var results = await Query()
			.Where(r => r.PublicRoute != null)
			.Include(r => r.PublicRoute)
			.ThenInclude(pr => pr!.PublicRouteGroup)
			.ThenInclude(prg => prg.Direction)
			.ToArrayAsync(cancellationToken: cancellationToken);

		return results.ToImmutableArray();
	}
}
