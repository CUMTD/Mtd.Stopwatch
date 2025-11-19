namespace Mtd.Stopwatch.Core.Entities.Realtime;

public class MonitoredVehicleOccupancy
{
	public float OccupancyPercentage { get; set; }
	public int PassengerCount { get; set; }
	public int Capacity { get; set; }
	public int SeatCount { get; set; }
}
