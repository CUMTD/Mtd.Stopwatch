using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.JoinTables;

public class RerouteToPublicRoute
{
	public required string RerouteId { get; set; }
	public required string PublicRouteId { get; set; }
	public required virtual Reroute Reroute { get; set; }
	public required virtual PublicRoute PublicRoute { get; set; }
}
