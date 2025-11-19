using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class StopTime : Entity, IImportable
{
	public required string TripId { get; set; }
	public required short StopSequence { get; set; }
	public required DateTime ArrivalTime { get; set; }
	public required bool ArrivalPastMidnight { get; set; }
	public required DateTime DepartureTime { get; set; }
	public required bool DeparturePastMidnight { get; set; }
	public required string StopId { get; set; }
	public string? StopHeadsign { get; set; }
	public required PickupDropoffType PickupType { get; set; } = PickupDropoffType.Regular;
	public required PickupDropoffType DropOffType { get; set; } = PickupDropoffType.Regular;
	public required bool Timepoint { get; set; }
	public required DateTime ImportTime { get; set; }

	public virtual required ChildStop Stop { get; set; }
	public virtual required Trip Trip { get; set; }

	protected StopTime()
	{
	}

	[SetsRequiredMembers]
	public StopTime(string tripId, short stopSequence, DateTime arrivalTime, bool arrivalPastMidnight,
		DateTime departureTime, bool departurePastMidnight, string stopId, string stopHeadsign,
		PickupDropoffType pickupType, PickupDropoffType dropoffType, bool timepoint, DateTime importTime) : this()
	{
		TripId = tripId;
		StopSequence = stopSequence;
		ArrivalTime = arrivalTime;
		ArrivalPastMidnight = arrivalPastMidnight;
		DepartureTime = departureTime;
		DeparturePastMidnight = departurePastMidnight;
		StopId = stopId;
		StopHeadsign = stopHeadsign;
		PickupType = pickupType;
		DropOffType = dropoffType;
		Timepoint = timepoint;
		ImportTime = importTime;
		Stop = null!;
		Trip = null!;
	}
}
