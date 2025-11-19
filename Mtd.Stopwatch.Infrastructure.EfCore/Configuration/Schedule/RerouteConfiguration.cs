using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;
using Mtd.Stopwatch.Infrastructure.EFCore.Configuration.JoinTables;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal partial class RerouteConfiguration : IEntityTypeConfiguration<Reroute>
{
	public void Configure(EntityTypeBuilder<Reroute> builder)
	{
		builder
			.ToTable("Reroute", "schedule");

		builder
			.HasKey(a => a.Id);

		builder
			.HasMany(rr => rr.AffectedRoutes)
			.WithMany(ar => ar.Reroutes)
			.UsingEntity<RerouteToPublicRoute>(
				j => j.HasOne(t => t.PublicRoute).WithMany().HasForeignKey(t => t.PublicRouteId),
				j => j.HasOne(t => t.Reroute).WithMany().HasForeignKey(t => t.RerouteId),
				j => j.ToTable("RerouteToPublicRoute", "schedule").HasKey(t => new { t.PublicRouteId, t.RerouteId })
			);
	}
}
