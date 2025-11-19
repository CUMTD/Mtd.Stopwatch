using Mtd.Core.Entities;

namespace Mtd.Stopwatch.Core.Entities.Schedule;

public class Direction : GuidEntity
{
	public required string ZeroName { get; set; }
	public required string ZeroShortName { get; set; }
	public required string OneName { get; set; }
	public required string OneShortName { get; set; }

	public string CombinedName => $"{ZeroName}/{OneName}";

	public required bool Show { get; set; }

	protected Direction()
	{
		Show = true;
	}

	public Direction(string zeroName, string zeroShortName, string oneName, string oneShortName) : this()
	{
		ZeroName = zeroName;
		ZeroShortName = zeroShortName;
		OneName = oneName;
		OneShortName = oneShortName;
	}
}
