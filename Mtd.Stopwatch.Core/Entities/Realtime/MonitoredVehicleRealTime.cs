namespace Mtd.Stopwatch.Core.Entities.Realtime;

public class MonitoredVehicleRealTime
{
	public DateTimeOffset? ScheduledArrival { get; set; }
	public DateTimeOffset? ExpectedArrival { get; set; }
	public DateTimeOffset ScheduledDeparture { get; set; }
	public DateTimeOffset? ExpectedDeparture { get; set; }
	public long OnTimePerformance => ExpectedDeparture.HasValue ? (long)Math.Round((ExpectedDeparture.Value - ScheduledDeparture).TotalSeconds) : -1;
}
