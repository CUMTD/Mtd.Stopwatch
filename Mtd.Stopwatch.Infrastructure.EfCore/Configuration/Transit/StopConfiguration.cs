using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class StopConfiguration : IEntityTypeConfiguration<Stop>
{
	public void Configure(EntityTypeBuilder<Stop> builder)
	{
		builder
			.ToTable("Stop", "transit");

		builder
			.HasKey(t => t.Id);

		builder
			.Property(t => t.Id)
			.HasColumnName("Id")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(t => t.Name)
			.HasColumnName("Name")
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
			.Property(t => t.Description)
			.HasColumnName("Description")
			.IsRequired(false);

		builder
			.Property(t => t.Url)
			.HasColumnName("Url")
			.IsRequired(false);

		builder
			.Property(t => t.Timezone)
			.HasColumnName("Timezone")
			.IsRequired();

		builder
			.Property(t => t.Accessible)
			.HasColumnName("Accessible")
			.IsRequired();

		builder
			.Property(t => t.Active)
			.HasColumnName("Active")
			.IsRequired();

		builder
			.HasDiscriminator<byte>("Discriminator")
			.HasValue<ParentStop>(1)
			.HasValue<ChildStop>(2);
	}
}
