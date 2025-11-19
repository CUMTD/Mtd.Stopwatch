using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class ShapePoint : Entity, IEquatable<ShapePoint>
{
	public required string ShapeId { get; set; }
	public required double Latitude { get; set; }
	public required double Longitude { get; set; }
	public required short Sequence { get; set; }
	public required decimal DistanceTraveled { get; set; }
	public string? StopId { get; set; }
	public virtual required Shape Shape { get; set; }

	protected ShapePoint()
	{
	}

	[SetsRequiredMembers]
	public ShapePoint(string shapeId, double latitude, double longitude, short sequence, decimal distanceTraveled)
	{
		ShapeId = shapeId;
		Shape = null!;
		Sequence = sequence;
		DistanceTraveled = distanceTraveled;
		Latitude = latitude;
		Longitude = longitude;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ShapePoint sp)
		{
			return Equals(sp);
		}

		return false;
	}

	public bool Equals(ShapePoint? other)
	{
		if (other is null)
		{
			return false;
		}

		return ShapeId == other.ShapeId && Sequence == other.Sequence;
	}

	public override int GetHashCode() => ShapeId.GetHashCode() ^ Sequence.GetHashCode();
}
