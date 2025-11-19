using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class ParentStopConfiguration : IEntityTypeConfiguration<ParentStop>
{
	public void Configure(EntityTypeBuilder<ParentStop> builder) => builder
			.Ignore(ps => ps.FilteredChildren);
}
