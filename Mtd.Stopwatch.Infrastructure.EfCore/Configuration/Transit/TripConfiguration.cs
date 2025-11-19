using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class TripConfiguration : IEntityTypeConfiguration<Trip>
{
	public void Configure(EntityTypeBuilder<Trip> builder)
	{
		builder
			.ToTable("Trip", "transit");

		builder
			.HasKey(t => t.Id);

		builder
			.Property(t => t.Id)
			.HasColumnName("Id")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(t => t.ServiceId)
			.HasColumnName("ServiceId")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(t => t.RouteId)
			.HasColumnName("RouteId")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(t => t.BlockId)
			.HasColumnName("BlockId")
			.HasMaxLength(150)
			.IsRequired();

		builder
			.Property(t => t.ShapeId)
			.HasColumnName("ShapeId")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(t => t.Headsign)
			.HasColumnName("Headsign")
			.IsRequired();

		builder
			.Property(t => t.ShortName)
			.HasColumnName("ShortName")
			.HasMaxLength(100)
			.IsRequired();

		builder
			.Property(t => t.Direction)
			.HasColumnName("Direction")
			.IsRequired();

		builder
			.Property(t => t.Accessible)
			.HasColumnName("Accessible")
			.IsRequired();

		builder
			.Property(t => t.Bikes)
			.HasColumnName("Bikes")
			.IsRequired();

		builder
			.HasOne(t => t.Route)
			.WithMany(r => r.Trips)
			.HasForeignKey(t => t.RouteId)
			.IsRequired();

		builder
			.HasOne(t => t.Shape)
			.WithMany(s => s.Trips)
			.HasForeignKey(t => t.ShapeId)
			.IsRequired();
	}
}
