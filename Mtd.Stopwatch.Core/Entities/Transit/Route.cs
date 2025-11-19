using Mtd.Core.Entities;
using Mtd.Stopwatch.Core.Entities.Schedule;
using System.Diagnostics.CodeAnalysis;

namespace Mtd.Stopwatch.Core.Entities.Transit;

public class Route : Entity, IIdentity<string>, IComparable<Route>, IImportable
{
	private static readonly Dictionary<string, int> _groupExceptions = new()
	{
		{ "9A", 9 },
		{ "9B", 9 },
		{ "10", 10 },
		{"100", 1},
		{"180", 180},
		{"280", 280},
		{"335", 335}
	};

	private static readonly Dictionary<string, int> _sortExceptions = new()
	{
		["9A"] = 9,
		["9B"] = 9
	};

	public required string Id { get; set; }
	public required string AgencyId { get; set; }
	public required string Number { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required RouteType Type { get; set; }
	public string? Url { get; set; }
	public required string Color { get; set; }
	public required string TextColor { get; set; }
	public string? PublicRouteId { get; set; }
	public bool Active { get; set; }

	public bool? IsIStop { get; set; }
	public required DateTime ImportTime { get; set; }
	public virtual required Agency Agency { get; set; }
	public virtual ICollection<Trip> Trips { get; set; }
	public virtual PublicRoute? PublicRoute { get; set; }
	public string FriendlyName => $"{Number} {Name}";

	protected Route()
	{
		Trips = [];
	}

	[SetsRequiredMembers]
	public Route(string id, string agencyId, string number, string name, string url, string color, string textColor, DateTime importTime, RouteType type = RouteType.Bus, bool? isIStop = null, bool active = true) : this()
	{
		Id = id;
		AgencyId = agencyId;
		Number = number;
		Name = name;
		Type = type;
		Url = url;
		Color = color;
		TextColor = textColor;
		IsIStop = isIStop;
		Active = active;
		ImportTime = importTime;
		Agency = null!;
	}

	public int CompareTo(Route? other)
	{
		if (other is null)
		{
			return 1;
		}

		var groupCompare = GetGroupNumber(Number).CompareTo(GetGroupNumber(other.Number));
		if (groupCompare == 0)
		{
			var sortCompare = GetSortNumber(Number).CompareTo(GetSortNumber(other.Number));
			return sortCompare == 0 ?
				string.Compare(Name, other.Name, StringComparison.CurrentCultureIgnoreCase) :
				sortCompare;
		}

		return groupCompare;
	}

	private static int GetGroupNumber(string number)
	{
		if (_groupExceptions.TryGetValue(number, out var value))
		{
			return value;
		}

		var numberToParse = number.TrimEnd('0');
		return int.Parse(numberToParse);
	}

	private static int GetSortNumber(string number) => _sortExceptions.TryGetValue(number, out var value) ? value : int.Parse(number);
}
