using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal class PublicRouteConfiguration : IEntityTypeConfiguration<PublicRoute>
{
	public void Configure(EntityTypeBuilder<PublicRoute> builder)
	{
		builder
			.ToTable("PublicRoute", "schedule");

		builder
			.HasKey(a => a.Id);

		builder
			.HasOne(pr => pr.PublicRouteGroup)
			.WithMany(rg => rg.PublicRoutes)
			.HasForeignKey(pr => pr.PublicRouteGroupId)
			.IsRequired();

		builder
			.HasOne(pr => pr.Daytype)
			.WithMany(dt => dt.Routes)
			.HasForeignKey(pr => pr.DaytypeId)
			.IsRequired();
	}
}
