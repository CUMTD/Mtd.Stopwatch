namespace Mtd.Stopwatch.Core.Entities.Realtime;

public class MonitoredVehicleItinerary
{
	public string StopId { get; set; } = default!;
	public string? StopName { get; set; }

	public MonitoredVehicleItinerary()
	{
	}

	public MonitoredVehicleItinerary(string stopId, string? stopName)
	{
		StopId = stopId;
		StopName = stopName;
	}
}
