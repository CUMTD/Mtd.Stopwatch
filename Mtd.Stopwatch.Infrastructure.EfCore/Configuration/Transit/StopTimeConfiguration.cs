using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class StopTimeConfiguration : IEntityTypeConfiguration<StopTime>
{
	public void Configure(EntityTypeBuilder<StopTime> builder)
	{
		builder
			.ToTable("StopTime", "transit");

		builder
			.HasKey(st => new { st.TripId, st.StopSequence });

		builder
			.Property(t => t.TripId)
			.HasColumnName("TripId")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(t => t.TripId)
			.HasColumnName("TripId")
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(t => t.StopSequence)
			.HasColumnName("StopSequence")
			.IsRequired();

		builder
			.Property(t => t.ArrivalTime)
			.HasColumnName("ArrivalTime")
			.IsRequired();

		builder
			.Property(t => t.DepartureTime)
			.HasColumnName("DepartureTime")
			.IsRequired();

		builder
			.Property(t => t.StopId)
			.HasColumnName("StopId")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(t => t.StopHeadsign)
			.HasColumnName("StopHeadsign")
			.IsRequired(false);

		builder
			.Property(t => t.PickupType)
			.HasColumnName("PickupType")
			.IsRequired();

		builder
			.Property(t => t.DropOffType)
			.HasColumnName("DropOffType")
			.IsRequired();

		builder
			.Property(t => t.Timepoint)
			.HasColumnName("Timepoint")
			.IsRequired();

		builder
			.HasOne(t => t.Stop)
			.WithMany(s => s.StopTimes)
			.HasForeignKey(s => s.StopId)
			.IsRequired();

		builder
			.HasOne(t => t.Trip)
			.WithMany(t => t.StopTimes)
			.HasForeignKey(t => t.TripId)
			.IsRequired();
	}
}
