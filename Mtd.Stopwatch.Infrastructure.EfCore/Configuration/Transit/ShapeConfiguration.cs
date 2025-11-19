using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class ShapeConfiguration : IEntityTypeConfiguration<Shape>
{
	public void Configure(EntityTypeBuilder<Shape> builder)
	{
		builder
			.ToTable("Shape", "transit");

		builder
			.HasKey(s => s.Id);

		builder
			.Property(s => s.Id)
			.HasColumnName("Id")
			.HasMaxLength(60)
			.IsRequired();
	}
}
