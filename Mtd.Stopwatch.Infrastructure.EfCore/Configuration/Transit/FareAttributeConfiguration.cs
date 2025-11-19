using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class FareAttributeConfiguration : IEntityTypeConfiguration<FareAttribute>
{
	public void Configure(EntityTypeBuilder<FareAttribute> builder)
	{
		builder
			.ToTable("FareAttribute", "transit");

		builder
			.HasKey(a => a.Id);

		builder
			.Property(a => a.Id)
			.HasColumnName("Id")
			.HasMaxLength(20)
			.IsRequired();

		builder
			.Property(a => a.Price)
			.HasColumnName("Price")
			.HasPrecision(9, 4)
			.IsRequired();

		builder
			.Property(a => a.Currency)
			.HasColumnName("Currency")
			.HasMaxLength(10)
			.IsRequired();

		builder
			.Property(a => a.CanPrepay)
			.HasColumnName("CanPrepay")
			.IsRequired();

		builder
			.Property(a => a.Transfers)
			.HasColumnName("Transfers")
			.IsRequired();
	}
}
