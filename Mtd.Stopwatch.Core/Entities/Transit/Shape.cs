using Mtd.Core.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class Shape : Entity, IIdentity<string>, IImportable
{
	public required string Id { get; set; }
	public required DateTime ImportTime { get; set; }
	public virtual ICollection<Trip> Trips { get; set; }
	public virtual ICollection<ShapePoint> Points { get; set; }

	protected Shape()
	{
		Trips = [];
		Points = [];
	}

	[SetsRequiredMembers]
	public Shape(string id, DateTime importTime) : this()
	{
		Id = id;
		ImportTime = importTime;
	}

	protected bool Equals(Shape other) => string.Equals(Id, other.Id);
}
