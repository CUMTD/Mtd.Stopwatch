using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class ShapePointConfiguration : IEntityTypeConfiguration<ShapePoint>
{
	public void Configure(EntityTypeBuilder<ShapePoint> builder)
	{
		builder
			.ToTable("ShapePoint", "transit");

		builder
			.HasKey(s => new { s.ShapeId, s.Sequence });

		builder
			.Property(s => s.ShapeId)
			.HasColumnName("ShapeId")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(s => s.Sequence)
			.HasColumnName("sequence")
			.IsRequired();

		builder
			.Property(t => t.Latitude)
			.HasColumnName("Latitude")
			.IsRequired();

		builder
			.Property(t => t.Longitude)
			.HasColumnName("Longitude")
			.IsRequired();

		builder
			.Property(s => s.DistanceTraveled)
			.HasColumnName("DistnaceTraveled")
			.HasPrecision(9, 3)
			.IsRequired();

		builder
			.HasOne(t => t.Shape)
			.WithMany(s => s.Points)
			.HasForeignKey(t => t.ShapeId);
	}
}
