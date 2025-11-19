using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class ParentStop : Stop
{
	public bool? IsIStop { get; set; }

	public bool IsStation { get; set; }

	public bool IsTimepoint { get; set; }

	public virtual ICollection<ChildStop> ChildStops { get; set; }

	public virtual IEnumerable<ChildStop> FilteredChildren =>
		ChildStops
			?.Where(cs => cs.Active) ?? [];

	protected ParentStop()
	{
		ChildStops = [];
	}

	[SetsRequiredMembers]
	public ParentStop(string id, string name, string? city, double latitude, double longitude, DateTime importTime, string timezone = "America/Chicago", bool accessible = true, bool active = true)
		: base(id, name, latitude, longitude, city, importTime, timezone, accessible, active)
	{
		ChildStops = [];
	}
}
