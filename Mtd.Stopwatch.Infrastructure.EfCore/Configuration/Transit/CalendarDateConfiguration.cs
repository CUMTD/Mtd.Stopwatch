using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;
using Mtd.Stopwatch.Infrastructure.EFCore.Configuration.JoinTables;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class CalendarDateConfiguration : IEntityTypeConfiguration<CalendarDate>
{
	public void Configure(EntityTypeBuilder<CalendarDate> builder)
	{
		builder
			.ToTable("CalendarDate", "transit");

		builder
			.HasKey(cd => new { cd.ServiceId, cd.Date });

		builder
			.Property(cd => cd.ServiceId)
			.HasColumnName("ServiceId")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(cd => cd.Date)
			.HasColumnName("Date")
			.IsRequired();

		builder
			.Property(cd => cd.HasService)
			.IsRequired();

		builder
			.HasMany(cd => cd.Trips)
			.WithMany(t => t.CalendarDates)
			.UsingEntity<TripToCalendarDate>(
				j => j.HasOne(t => t.Trip).WithMany().HasForeignKey(t => t.TripId).IsRequired(),
				j => j.HasOne(t => t.CalendarDate).WithMany().HasForeignKey(t => new { t.ServiceId, t.Date }).IsRequired(),
				j => j.ToTable("TripToCalendarDate", "transit").HasKey(t => new { t.TripId, t.ServiceId, t.Date })
			);
	}
}
