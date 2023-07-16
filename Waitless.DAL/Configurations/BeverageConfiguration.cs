using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageConfiguration : BaseConfiguration<Beverage>
{
    public override void Configure(EntityTypeBuilder<Beverage> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage");

        builder.Property(c => c.Price)
            .HasColumnType("decimal(18,2)");

        builder.HasIndex(x => x.BeverageSizeId);
    }
}