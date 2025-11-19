using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.JoinTables;

public class TripToCalendarDate
{
	public required string TripId { get; set; }
	public required string ServiceId { get; set; }
	public DateTime Date { get; set; }
	public required virtual Trip Trip { get; set; }
	public required virtual CalendarDate CalendarDate { get; set; }
}
