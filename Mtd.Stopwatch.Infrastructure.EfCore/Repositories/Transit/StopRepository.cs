using Microsoft.EntityFrameworkCore;
using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;
using System.Collections.Immutable;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class StopRepository(StopwatchContext context)
	: AsyncEFIdentifiableRepository<string, Stop>(context), IStopRepository<Stop, IReadOnlyCollection<Stop>>
{
	public async Task<IReadOnlyCollection<Stop>> GetAllActiveAsync(CancellationToken cancellationToken)
	{
		var result = await Query()
		.Where(s => s.Active)
		.ToArrayAsync(cancellationToken).ConfigureAwait(false);

		return result.ToImmutableArray();
	}
}
