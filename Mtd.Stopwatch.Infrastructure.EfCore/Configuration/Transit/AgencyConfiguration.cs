using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class AgencyConfiguration : IEntityTypeConfiguration<Agency>
{
	public void Configure(EntityTypeBuilder<Agency> builder)
	{
		builder
			.ToTable("Agency", "transit");

		builder
			.HasKey(a => a.Id);

		builder
			.Property(a => a.Id)
			.HasColumnName("Id")
			.HasMaxLength(20)
			.IsRequired();

		builder
			.Property(a => a.Name)
			.HasColumnName("Name")
			.IsRequired();

		builder
			.Property(a => a.Url)
			.HasColumnName("Url")
			.IsRequired();

		builder
			.Property(a => a.Timezone)
			.HasColumnName("Timezone")
			.HasMaxLength(100)
			.IsRequired();

		builder
			.Property(a => a.Language)
			.HasColumnName("Language")
			.HasMaxLength(10)
			.IsRequired();

		builder
			.Property(a => a.Phone)
			.HasColumnName("Phone")
			.HasMaxLength(20)
			.IsRequired();

		builder
			.Property(a => a.FareUrl)
			.HasColumnName("FareUrl")
			.IsRequired(false);

		builder
			.Property(a => a.Email)
			.HasColumnName("Email")
			.IsRequired();
	}
}
