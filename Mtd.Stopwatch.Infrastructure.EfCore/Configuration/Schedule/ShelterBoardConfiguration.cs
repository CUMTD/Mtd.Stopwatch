using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Schedule;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Schedule;

internal class ShelterBoardConfiguration : IEntityTypeConfiguration<ShelterBoard>
{
	public void Configure(EntityTypeBuilder<ShelterBoard> builder)
	{
		builder
			.ToTable("ShelterBoard", "schedule");

		builder
			.HasKey(sb => sb.Id);

		builder
			.Property(sb => sb.Id)
			.HasColumnName("Id")
			.HasColumnType("nchar(32)")
			.IsRequired();

		builder
			.Property(sb => sb.StopId)
			.HasColumnName("StopId")
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(sb => sb.Name)
			.HasColumnName("Name")
			.HasMaxLength(175)
			.IsRequired();

		builder
			.Property(sb => sb.WidthInches)
			.HasColumnName("WidthInches")
			.HasPrecision(18, 2)
			.IsRequired();

		builder
			.Property(sb => sb.HeightInches)
			.HasColumnName("HeightInches")
			.HasPrecision(18, 2)
			.IsRequired();

		builder
			.Property(sb => sb.FrameType)
			.HasColumnName("FrameType")
			.IsRequired();

		builder
			.Property(sb => sb.ContentType)
			.HasColumnName("ContentType")
			.IsRequired();

		builder
			.Property(sb => sb.Notes)
			.HasColumnName("Notes")
			.HasMaxLength(256)
			.IsRequired(false);

		builder
			.HasOne(sb => sb.Stop)
			.WithMany()
			.HasForeignKey(sb => sb.StopId)
			.IsRequired();
	}
}
