using Mtd.Core.Entities;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Core.Entities.Schedule;

public class PublicRoute : GuidEntity, IComparable<PublicRoute>
{
	public string? RouteNumber { get; set; }
	public string FullRouteName => $"{RouteNumber} {PublicRouteGroup?.RouteName}";
	public string FullZeroRouteName => $"{RouteNumber}{PublicRouteGroup?.Direction?.ZeroShortName} {PublicRouteGroup?.RouteName}";
	public string FullOneRouteName => $"{RouteNumber}{PublicRouteGroup?.Direction?.OneShortName} {PublicRouteGroup?.RouteName}";
	public required DateTime FirstTrip { get; set; }
	public required DateTime LastTrip { get; set; }
	public required bool LastTripAfterMidnight { get; set; }
	public required string DaytypeId { get; set; }
	public required string PublicRouteGroupId { get; set; }

	public bool NoTrips
	{
		get
		{
			var midnight = new DateTime(2021, 1, 1, 0, 0, 0).TimeOfDay;
			return FirstTrip.TimeOfDay == midnight && LastTrip.TimeOfDay == midnight && !LastTripAfterMidnight;
		}
	}

	public required bool Active { get; set; }
	public virtual required Daytype Daytype { get; set; }
	public virtual required PublicRouteGroup PublicRouteGroup { get; set; }
	public virtual ICollection<Route> Routes { get; set; }
	public virtual ICollection<Reroute> Reroutes { get; set; }

	protected PublicRoute()
	{
		Active = true;
		Routes = [];
		Reroutes = [];
	}

	public PublicRoute(string routeNumber, string daytypeId, string publicRouteGroupId) : this()
	{
		RouteNumber = routeNumber;
		DaytypeId = daytypeId;
		PublicRouteGroupId = publicRouteGroupId;
	}

	/// <summary>
	/// See if this route is active at the provided time.
	/// </summary>
	/// <param name="time">The time to check if the route is active</param>
	/// <returns>True if the route is active. False if the route is inactive.</returns>
	public bool ActiveAtTime(DateTime time)
	{
		var tod = time.TimeOfDay;
		var ft = FirstTrip.TimeOfDay;
		var lt = LastTrip.TimeOfDay;
		var daytypes = (Daytype?.DaysOfWeek ?? []).ToArray();
		if (LastTripAfterMidnight)
		{
			var midnight = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
				DateTime.Now.Day, 0, 0, 0).TimeOfDay;

			if (tod >= ft && daytypes.Contains(time.DayOfWeek))
			{
				return true;
			}

			var dayBefore = time.AddDays(-1).DayOfWeek;
			if (tod < lt && tod > midnight && daytypes.Contains(dayBefore))
			{
				return true;
			}
		}
		else
		{
			if (tod > ft && tod < lt && daytypes.Contains(time.DayOfWeek))
			{
				return true;
			}
		}

		return false;
	}

	public int CompareTo(PublicRoute? other)
	{
		if (other is null)
		{
			return 1;
		}

		var thisGroupSort = PublicRouteGroup?.SortNumber;
		if (thisGroupSort.HasValue)
		{
			var otherGroupSort = other?.PublicRouteGroup?.SortNumber;
			if (otherGroupSort.HasValue)
			{
				var publicCompare = thisGroupSort.Value.CompareTo(otherGroupSort.Value);
				if (publicCompare != 0)
				{
					return publicCompare;
				}
			}
			else
			{
				return 1;
			}
		}

		return string.Compare(FullRouteName, other?.FullRouteName, StringComparison.Ordinal);
	}
}
