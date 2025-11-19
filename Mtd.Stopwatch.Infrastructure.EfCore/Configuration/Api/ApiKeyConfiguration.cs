using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Api;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Api;

internal class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
{
	public void Configure(EntityTypeBuilder<ApiKey> builder)
	{
		builder
				.ToTable("ApiKey", "api");

		builder
			.HasKey(ak => ak.Key);

		builder
			.Property(ak => ak.Key)
			.HasMaxLength(36)
			.IsRequired();

		builder
			.Property(ak => ak.DeveloperId)
			.IsRequired();

		builder
			.Property(ak => ak.Name)
			.HasMaxLength(100)
			.IsRequired();

		builder
			.Property(ak => ak.Notes)
			.IsRequired(false);

		builder
			.Property(ak => ak.IsActive)
			.HasDefaultValue(true)
			.IsRequired();

		builder
			.HasOne(ak => ak.Developer)
			.WithMany(d => d.ApiKeys)
			.HasForeignKey(ak => ak.DeveloperId);

	}
}
