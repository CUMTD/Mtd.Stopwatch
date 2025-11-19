using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
	public void Configure(EntityTypeBuilder<Vehicle> builder)
	{
		builder.ToTable("Vehicle", "transit");

		builder.HasKey(vc => vc.Id);

		builder
			.Property(vc => vc.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

		builder
			.Property(vc => vc.VehicleNumber)
				.HasColumnName("VehicleNumber")
				.HasMaxLength(50)
				.IsRequired(false);

		builder
			.Property(vc => vc.VehicleConfigurationId)
				.HasColumnName("VehicleConfigurationId")
				.HasMaxLength(36)
				.IsRequired();

		builder
			.Property(vc => vc.IsActive)
				.HasColumnName("IsActive")
				.IsRequired();

		builder
			.Property(vc => vc.VIN)
				.HasColumnName("VIN")
			.HasMaxLength(17)
			.IsRequired(false);

		builder
			.Property(vc => vc.LicensePlateNumber)
				.HasColumnName("LicensePlateNumber")
			.HasMaxLength(10)
			.IsRequired(false);

		builder
			.Property(vc => vc.DateInService)
			.HasColumnName("DateInService")
				.IsRequired(false);

		builder
			.HasOne(f => f.VehicleConfiguration)
			.WithMany(vc => vc.Vehicles)
			.HasForeignKey(f => f.VehicleConfigurationId);
	}
}
