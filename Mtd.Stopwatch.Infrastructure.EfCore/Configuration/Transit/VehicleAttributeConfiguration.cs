using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class VehicleAttributeConfiguration : IEntityTypeConfiguration<VehicleAttribute>
{
	public void Configure(EntityTypeBuilder<VehicleAttribute> builder)
	{
		builder.ToTable("VehicleAttribute", "transit");

		builder.HasKey(vac => new { vac.VehicleId, vac.Name });

		builder
			.Property(vac => vac.VehicleId)
				.HasColumnName("VehicleId")
				.HasMaxLength(36)
				.IsRequired();

		builder
			.Property(vac => vac.Name)
			.HasColumnName("Name")
			.HasMaxLength(100)
				.IsRequired();

		builder
			.Property(vac => vac.Value)
				.HasColumnName("Value")
				.HasMaxLength(500)
				.IsRequired();

		builder
			.HasOne(vac => vac.Vehicle)
			.WithMany(v => v.Attributes)
			.HasForeignKey(vac => vac.VehicleId);
	}
}
