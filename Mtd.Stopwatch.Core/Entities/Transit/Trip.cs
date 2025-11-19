using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class Trip : Entity, IIdentity<string>, IImportable
{
	public required string Id { get; set; }
	public required string ServiceId { get; set; }
	public required string RouteId { get; set; }
	public required string BlockId { get; set; }
	public required string ShapeId { get; set; }
	public required string Headsign { get; set; }
	public required string ShortName { get; set; }
	public required byte Direction { get; set; }
	public required bool Accessible { get; set; }
	public required bool Bikes { get; set; }
	public DateTime ImportTime { get; set; }

	public virtual required Route Route { get; set; }
	public virtual ICollection<CalendarDate> CalendarDates { get; set; }

	public virtual ICollection<StopTime> StopTimes { get; set; }
	public virtual required Shape Shape { get; set; }

	public string FriendlyHeadsign => string.IsNullOrWhiteSpace(Headsign)
				? string.Empty
				: Headsign[(Headsign.IndexOf('-') + 2)..].Trim();

	protected Trip()
	{
		CalendarDates = [];
		StopTimes = [];
	}

	[SetsRequiredMembers]
	public Trip(string id, string serviceId, string routeId, string blockId, string shapeId, string headsign,
		string shortName, byte direction, DateTime importTime, bool accessible = true, bool bikes = true) : this()
	{
		Id = id;
		ServiceId = serviceId;
		RouteId = routeId;
		BlockId = blockId;
		ShapeId = shapeId;
		Headsign = headsign;
		ShortName = shortName;
		Direction = direction;
		Accessible = accessible;
		Bikes = bikes;
		ImportTime = importTime;
		Route = null!;
		Shape = null!;
	}
}
