using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal class DaytypeConfiguration : IEntityTypeConfiguration<Daytype>
{
	public void Configure(EntityTypeBuilder<Daytype> builder)
	{
		builder
			.ToTable("Daytype", "schedule");
		builder
			.HasKey(a => a.Id);

		builder
			.Property(dt => dt.DaysOfWeekString)
			.HasColumnName("DaysOfWeek");
	}
}
