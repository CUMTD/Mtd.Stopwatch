using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class ImportLogConfiguration : IEntityTypeConfiguration<ImportLog>
{
	public void Configure(EntityTypeBuilder<ImportLog> builder)
	{
		builder
			.ToTable("ImportLog", "transit");

		builder
			.HasKey(l => l.Id);

		builder
			.Property(l => l.Id)
			.HasColumnName("Id")
			.HasMaxLength(36)
			.IsRequired();

		builder
			.Property(l => l.Start)
			.IsRequired();

		builder
			.Property(l => l.Finish)
			.IsRequired(false);

		builder
			.Property(l => l.Success)
			.IsRequired();

		builder
			.Property(l => l.Ticks)
			.IsRequired(false);

		builder
			.Ignore(l => l.ElapsedTime);
	}
}
