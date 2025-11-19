using Mtd.Infrastructure.EFCore.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Repositories.Transit;

public class CalendarDateRepository(StopwatchContext context)
	: AsyncEFRepository<CalendarDate>(context), ICalendarDateRepository<IReadOnlyCollection<CalendarDate>>
{
	public async Task<CalendarDate> GetByIdentityAsync(string serviceId, DateTime date, CancellationToken cancellationToken)
	{
		var result = await GetByIdentityAsync(serviceId, date, cancellationToken)
			.ConfigureAwait(false);

		return result ?? throw new InvalidOperationException($"{serviceId},{date} not found.");
	}
	public async Task<CalendarDate?> GetByIdentityOrDefault(string serviceId, DateTime date, CancellationToken cancellationToken)
	{
		var result = await _dbSet
			.FindAsync([serviceId, date], cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		return result;
	}
}
