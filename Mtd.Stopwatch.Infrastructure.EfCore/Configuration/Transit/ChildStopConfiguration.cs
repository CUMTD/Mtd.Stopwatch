using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class ChildStopConfiguration : IEntityTypeConfiguration<ChildStop>
{
	public void Configure(EntityTypeBuilder<ChildStop> builder)
	{
		builder
			.Property(bp => bp.ParentStopId)
			.HasColumnName("ParentStopId")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.HasOne(bp => bp.ParentStop)
			.WithMany(ps => ps.ChildStops)
			.HasForeignKey(bp => bp.ParentStopId)
			.IsRequired();
	}
}
