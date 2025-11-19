using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal class DirectionConfiguration : IEntityTypeConfiguration<Direction>
{
	public void Configure(EntityTypeBuilder<Direction> builder)
	{
		builder
				.ToTable("Direction", "schedule");
		builder
				.HasKey(a => a.Id);
	}
}
