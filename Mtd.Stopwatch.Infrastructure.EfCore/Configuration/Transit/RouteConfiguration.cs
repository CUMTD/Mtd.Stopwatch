using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mtd.Stopwatch.Core.Entities.Transit;

namespace Mtd.Stopwatch.Infrastructure.EFCore.Configuration.Transit;

internal class RouteConfiguration : IEntityTypeConfiguration<Route>
{
	public void Configure(EntityTypeBuilder<Route> builder)
	{
		builder
			.ToTable("Route", "transit");

		builder
			.HasKey(r => r.Id);

		builder
			.Property(r => r.Id)
			.HasColumnName("Id")
			.HasMaxLength(60)
			.IsRequired();

		builder
			.Property(r => r.AgencyId)
			.HasColumnName("AgencyId")
			.HasMaxLength(20)
			.IsRequired();

		builder
			.Property(r => r.Number)
			.HasColumnName("Number")
			.HasMaxLength(4)
			.IsRequired();

		builder
			.Property(r => r.Name)
			.HasColumnName("Name")
			.HasMaxLength(150)
			.IsRequired();

		builder
			.Property(r => r.Description)
			.HasColumnName("Description")
			.IsRequired(false);

		builder
			.Property(r => r.Type)
			.HasColumnName("Type")
			.IsRequired();

		builder
			.Property(r => r.Url)
			.HasColumnName("Url")
			.IsRequired(false);

		builder
			.Property(r => r.Color)
			.HasColumnName("Color")
			.HasMaxLength(6)
			.IsRequired();

		builder
			.Property(r => r.TextColor)
			.HasColumnName("TextColor")
			.HasMaxLength(6)
			.IsRequired();

		builder
			.HasOne(r => r.Agency)
			.WithMany(a => a.Routes)
			.HasForeignKey(r => r.AgencyId)
			.IsRequired();

		builder
			.HasOne(r => r.PublicRoute)
			.WithMany(pr => pr.Routes)
			.HasForeignKey(r => r.PublicRouteId)
			.IsRequired(false);
	}
}
