using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal class PublicRouteGroupConfiguration : IEntityTypeConfiguration<PublicRouteGroup>
{
	public void Configure(EntityTypeBuilder<PublicRouteGroup> builder)
	{
		builder
				.ToTable("PublicRouteGroup", "schedule");
		builder
				.HasKey(a => a.Id);
		builder
			.HasOne(rg => rg.Direction)
			.WithMany()
			.HasForeignKey(rg => rg.DirectionId)
			.IsRequired();

		builder
			.Ignore(rg => rg.ActivePublicRoutes);
	}
}
