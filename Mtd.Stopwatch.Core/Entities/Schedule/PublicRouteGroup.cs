using Mtd.Core.Entities;
using System.Text;

namespace Mtd.Stopwatch.Core.Entities.Schedule;

public class PublicRouteGroup : GuidEntity
{
	public required short SortNumber { get; set; }
	public required string RouteName { get; set; }
	public required string HexColor { get; set; }
	public required string HexTextColor { get; set; }
	public required string DirectionId { get; set; }
	public required virtual Direction Direction { get; set; }
	public virtual ICollection<PublicRoute> PublicRoutes { get; set; }

	public IEnumerable<PublicRoute> ActivePublicRoutes => PublicRoutes?.Where(pr => pr.Active) ?? [];

	protected PublicRouteGroup()
	{
		PublicRoutes = [];
	}

	public PublicRouteGroup(short sortNumber, string routeName, string hexColor, string hexTextColor, string directionId) : this()
	{
		SortNumber = sortNumber;
		RouteName = routeName;
		HexColor = hexColor;
		HexTextColor = hexTextColor;
		DirectionId = directionId;
	}

	public string GetFormatAllPublicRouteNumbers()
	{
		if (PublicRoutes == null || PublicRoutes.Count == 0)
		{
			return SortNumber.ToString();
		}

		return PublicRoutes
			.Select(pr => pr.RouteNumber)
			.Distinct()
			.OrderBy(n => n)
			.Aggregate(new StringBuilder(), (sb, s) => sb.AppendFormat("{0}/", s), sb => sb.ToString())
			.TrimEnd('/');
	}
}
