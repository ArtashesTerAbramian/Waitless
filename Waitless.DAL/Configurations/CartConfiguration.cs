using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class CartConfiguration : BaseConfiguration<Cart>
{
    public override void Configure(EntityTypeBuilder<Cart> builder)
    {
        base.Configure(builder);

        builder.ToTable("cart");

        builder.Property(x => x.TotalPrice)
           .HasColumnType("numeric(18,2)");
    }
}
