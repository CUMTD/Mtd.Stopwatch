using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Mtd.Stopwatch.Core.Entities.Realtime;

public partial class Departure : IRealtimeData, IComparable<Departure>
{
	[GeneratedRegex("([0-9])+([A-Za-z])?\\s.*")]
	private static partial Regex NumberDirectionRegex();

	public required string StopId { get; set; }
	public string? Headsign { get; set; }
	public string? RouteId { get; set; }

	private string? _direction;
	public string? Direction
	{
		get => _direction;
		set
		{
			if ("clockwise".Equals(value, StringComparison.CurrentCultureIgnoreCase))
			{
				_direction = "A";
			}
			else if ("counter-clockwise".Equals(value, StringComparison.CurrentCultureIgnoreCase))
			{
				_direction = "B";
			}
			else
			{
				var info = CultureInfo.CurrentCulture;
				_direction = info.TextInfo.ToTitleCase(value?.ToLower() ?? string.Empty);
			}
		}
	}

	public string? BlockId { get; set; }
	public required DateTimeOffset RecordedTime { get; set; }
	public required DateTimeOffset? ScheduledDeparture { get; set; }
	public required DateTimeOffset? EstimatedDeparture { get; set; }
	public required string VehicleId { get; set; }
	public string? OriginStopId { get; set; }
	public string? DestinationStopId { get; set; }
	public required decimal Latitude { get; set; }
	public required decimal Longitude { get; set; }
	public string? ShapeId { get; set; }
	public string? TripPrefix { get; set; }
	public string? TripId
	{
		get
		{
			// We expect trips to be in the format <TRIP_ID>__<BLOCK_ID>
			// This checks to make sure it isn't already in that format
			// this prevents us from doing <TRIP_ID>__<BLOCK_ID>__<BLOCK_ID>
			// it will also just return the prefix if the block id is null or empty or if the trip id is null or empty.
			// this prevents us  from returning things like "__" or "__<BLOCK_ID>"
			if (string.IsNullOrEmpty(TripPrefix) || TripPrefix.Contains("__") || string.IsNullOrEmpty(BlockId))
			{
				return TripPrefix;
			}

			return $"{TripPrefix}__{BlockId?.Replace(" ", "_")}";
		}
	}

	public int MinutesTillDeparture
	{
		get
		{
			if (EstimatedDeparture == null)
			{
				return 0;
			}

			return (int)Math.Floor((EstimatedDeparture.Value - TimeProvider.System.GetLocalNow()).TotalMilliseconds);

		}
	}

	public required bool IsRealTime { get; set; }
	public bool IsHopper => CultureInfo.CurrentCulture.CompareInfo.IndexOf(RouteColor, "hopper", CompareOptions.IgnoreCase) >= 0; // invariant case compare
	public string? Destination { get; set; }

	public string DepartsIn
	{
		get
		{
			if (IsRealTime)
			{
				var minutes = MinutesTillDeparture;
				return minutes <= 0 ?
					"DUE" :
					$"{minutes} min{(minutes == 1 ? string.Empty : "s")}";
			}

			return EstimatedDeparture?.ToString("t") ?? "Unknown";
		}
	}

	public bool IsIStop { get; set; }

	private string? _routeNumber;

	public string? RouteNumber
	{
		get => _routeNumber;
		set
		{
			_routeNumber = string.Equals(value, "9a", StringComparison.CurrentCultureIgnoreCase) | string.Equals(value, "9b", StringComparison.CurrentCultureIgnoreCase)
				? "9"
				: value;
		}
	}

	public int RouteSortNumber => int.TryParse(RouteNumber, out var sort) ? sort : int.MaxValue;

	public string RouteColor
	{
		get
		{
			// routes are uppercase
			var route = Headsign
				?.Trim()
				.ToUpper();

			if (string.IsNullOrEmpty(route))
			{
				return string.Empty;
			}

			// if it is a hopper route is Title case and HOPPER is upper
			if (route.Contains("HOPPER"))
			{
				var textInfo = CultureInfo.CurrentCulture.TextInfo;
				// title case won't work if it's not lower case
				// use special character to hold place for replacement.
				route = textInfo.ToTitleCase(route.ToLower());
			}

			// if it starts with a number/direction (e.g. 5E)
			if (NumberDirectionRegex().IsMatch(route))
			{
				route = route.Split(' ')
					.Skip(1)
					.Aggregate(new StringBuilder(), (sb, s) => sb.AppendFormat("{0} ", s), sb => sb.ToString()).Trim();
			}

			return route;
		}
	}

	public string FriendlyRouteName
	{
		get
		{
			var direction = string.IsNullOrWhiteSpace(Direction) ? string.Empty : Direction[..1];
			return $"{RouteNumber}{direction} {RouteColor}";
		}
	}

	public string UniqueId => $"v-{VehicleId}_t-{TripPrefix}_b-{BlockId}_sd-{ScheduledDeparture:yyyyMMdd-HHmmss}";

	public Departure()
	{
		_routeNumber = string.Empty;
		_direction = string.Empty;
	}

	int IComparable<Departure>.CompareTo(Departure? other)
	{
		if (other is null)
		{
			return 1;
		}

		if (EstimatedDeparture < other.EstimatedDeparture)
		{
			return -1;
		}

		return EstimatedDeparture == other.EstimatedDeparture ? 0 : 1;
	}
}
