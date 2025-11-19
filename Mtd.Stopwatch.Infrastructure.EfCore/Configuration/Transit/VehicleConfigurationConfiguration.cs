using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class VehicleConfigurationConfiguration : IEntityTypeConfiguration<Core.Entities.Transit.VehicleConfiguration>
{
	public void Configure(EntityTypeBuilder<Core.Entities.Transit.VehicleConfiguration> builder)
	{
		builder.ToTable("VehicleConfiguration", "transit");

		builder
			.HasKey(fc => fc.Id);

		builder
			.Property(fc => fc.Id)
				.HasColumnName("Id")
				.HasMaxLength(36)
				.IsRequired();

		builder
			.Property(fc => fc.VehicleType)
				.HasColumnName("VehicleType")
			.HasColumnType("tinyint")
				.IsRequired();

		builder
			.Property(fc => fc.Year)
				.HasColumnName("Year")
				.IsRequired();

		builder
			.Property(fc => fc.Make)
				.HasColumnName("Make")
				.HasMaxLength(100)
				.IsRequired();

		builder
			.Property(fc => fc.Model)
				.HasColumnName("Model")
				.HasMaxLength(50)
				.IsRequired();

		builder
			.Property(fc => fc.LengthFeet)
				.HasColumnName("LengthFeet")
				.IsRequired(false);

		builder
			.Property(fc => fc.Powertrain)
				.HasColumnName("Powertrain")
			.HasColumnType("tinyint")
				.IsRequired();

		builder
			.Property(fc => fc.IsPublic)
				.HasColumnName("IsPublic")
				.IsRequired();

		_ = builder
			.HasMany(f => f.Vehicles)
			.WithOne()
			.IsRequired(false);

	}
}
