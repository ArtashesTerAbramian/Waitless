using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class CoffeeConfiguration : BaseConfiguration<Coffee>
{
    public override void Configure(EntityTypeBuilder<Coffee> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee");

        builder.Property(c => c.Price)
           .HasColumnType("decimal(18,2)");

        builder.HasIndex(x => new { x.CoffeeTypeId, x.BeverageSizeId });
    }
}
