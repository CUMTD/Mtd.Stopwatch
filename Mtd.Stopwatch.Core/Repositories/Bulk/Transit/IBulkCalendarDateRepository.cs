using Mtd.Core.Repositories;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Core.Repositories.Transit;

namespace Mtd.Stopwatch.Core.Repositories.Bulk.Transit;

public interface IBulkCalendarDateRepository<T_Collection> : ICalendarDateRepository<T_Collection>, IAsyncBulkWriteable<CalendarDate, T_Collection>
	where T_Collection : IEnumerable<CalendarDate>
{
}
