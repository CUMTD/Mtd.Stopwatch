using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Transit;

public interface ICalendarDateRepository<T_Collection> : IAsyncReadable<CalendarDate, T_Collection>, IAsyncWriteable<CalendarDate, T_Collection>, IDisposable
	where T_Collection : IEnumerable<CalendarDate>
{
	Task<CalendarDate> GetByIdentityAsync(string serviceId, DateTime date, CancellationToken cancellationToken);

	Task<CalendarDate?> GetByIdentityOrDefault(string serviceId, DateTime date, CancellationToken cancellationToken);
}
