using Microsoft.EntityFrameworkCore;
using Mtd.Stopwatch.Core.Entities.Api;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Api;
using Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;
using Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore;

public class StopwatchContext(DbContextOptions<StopwatchContext> options) : DbContext(options)
{
	public DbSet<Daytype> LogEntries { get; protected set; }
	public DbSet<Direction> Directions { get; protected set; }
	public DbSet<PublicRoute> PublicRoutes { get; protected set; }
	public DbSet<PublicRouteGroup> PublicRouteGroups { get; protected set; }
	public DbSet<ShelterBoard> ShelterBoards { get; protected set; }
	public DbSet<Agency> Agencies { get; protected set; }
	public DbSet<CalendarDate> CalendarDates { get; protected set; }
	public DbSet<Stop> Stops { get; protected set; }
	public DbSet<ChildStop> ChildStops { get; protected set; }
	public DbSet<ParentStop> ParentStops { get; protected set; }
	public DbSet<FareAttribute> FareAttributes { get; protected set; }
	public DbSet<ImportLog> ImportLogs { get; protected set; }
	public DbSet<Route> Routes { get; protected set; }
	public DbSet<Shape> Shapes { get; protected set; }
	public DbSet<StopTime> StopTimes { get; protected set; }
	public DbSet<Trip> Trips { get; protected set; }
	public DbSet<Reroute> ReRoute { get; protected set; }
	public DbSet<Developer> Developers { get; protected set; }
	public DbSet<ApiKey> ApiKeys { get; protected set; }
	public DbSet<Core.Entities.Transit.VehicleConfiguration> VehicleConfigurations { get; protected set; }
	public DbSet<Vehicle> Vehicles { get; protected set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		_ = builder.ApplyConfiguration(new DaytypeConfiguration());
		_ = builder.ApplyConfiguration(new DirectionConfiguration());
		_ = builder.ApplyConfiguration(new PublicRouteConfiguration());
		_ = builder.ApplyConfiguration(new PublicRouteGroupConfiguration());
		_ = builder.ApplyConfiguration(new RerouteConfiguration());
		_ = builder.ApplyConfiguration(new ShelterBoardConfiguration());
		_ = builder.ApplyConfiguration(new AgencyConfiguration());
		_ = builder.ApplyConfiguration(new CalendarDateConfiguration());
		_ = builder.ApplyConfiguration(new ChildStopConfiguration());
		_ = builder.ApplyConfiguration(new ParentStopConfiguration());
		_ = builder.ApplyConfiguration(new FareAttributeConfiguration());
		_ = builder.ApplyConfiguration(new ImportLogConfiguration());
		_ = builder.ApplyConfiguration(new RouteConfiguration());
		_ = builder.ApplyConfiguration(new ImportLogConfiguration());
		_ = builder.ApplyConfiguration(new ShapeConfiguration());
		_ = builder.ApplyConfiguration(new ShapePointConfiguration());
		_ = builder.ApplyConfiguration(new StopConfiguration());
		_ = builder.ApplyConfiguration(new StopTimeConfiguration());
		_ = builder.ApplyConfiguration(new TripConfiguration());
		_ = builder.ApplyConfiguration(new RerouteConfiguration());
		_ = builder.ApplyConfiguration(new DeveloperConfiguration());
		_ = builder.ApplyConfiguration(new ApiKeyConfiguration());
		_ = builder.ApplyConfiguration(new VehicleConfigurationConfiguration());
		_ = builder.ApplyConfiguration(new Configuration.Transit.VehicleConfiguration());
		_ = builder.ApplyConfiguration(new VehicleAttributeConfiguration());
	}
}
