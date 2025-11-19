using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Api;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Api;

internal class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
	public void Configure(EntityTypeBuilder<Developer> builder)
	{
		_ = builder
				.ToTable("Developer", "api");

		builder
			.HasKey(d => d.Id);

		builder
			.Property(ak => ak.Id)
			.HasMaxLength(36)
			.IsRequired();

		builder
			.Property(d => d.Name)
			.HasMaxLength(200)
			.IsRequired();

		builder
			.Property(d => d.TokensPerHour)
			.HasColumnType("int")
			.IsRequired();

		builder
			.Property(d => d.CurrentTokens)
			.HasColumnType("float")
			.IsRequired();

		builder
			.Property(d => d.LastTokenCountUpdate)
			.HasDefaultValue(DateTimeOffset.Now)
			.IsRequired();

		builder
			.Property(d => d.IsActive)
			.HasDefaultValue(true)
			.IsRequired();
	}
}
