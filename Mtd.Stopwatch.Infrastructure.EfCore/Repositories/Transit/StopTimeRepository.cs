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
}
