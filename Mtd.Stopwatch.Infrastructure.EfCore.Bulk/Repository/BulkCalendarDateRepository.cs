using Mtd.Infrastructure.EFCore.Bulk.Repository;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Bulk.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Bulk.Repository;

public class BulkCalendarDateRepository(ICalendarDateRepository<IReadOnlyCollection<CalendarDate>> calendarDateRepository, StopwatchContext dbContext)
	: AsyncBulkEFRepository<CalendarDate>(dbContext), IBulkCalendarDateRepository<IReadOnlyCollection<CalendarDate>>
{
	private readonly ICalendarDateRepository<IReadOnlyCollection<CalendarDate>> _calendarDateRepository = calendarDateRepository ?? throw new ArgumentNullException(nameof(calendarDateRepository));
	public Task<CalendarDate> GetByIdentityAsync(string serviceId, DateTime date, CancellationToken cancellationToken) =>
		_calendarDateRepository.GetByIdentityAsync(serviceId, date, cancellationToken);
	public Task<CalendarDate?> GetByIdentityOrDefault(string serviceId, DateTime date, CancellationToken cancellationToken) =>
		_calendarDateRepository.GetByIdentityOrDefault(serviceId, date, cancellationToken);
}
