using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class CartProductConfiguration : BaseConfiguration<CartProduct>
{
    public override void Configure(EntityTypeBuilder<CartProduct> builder)
    {
        base.Configure(builder);

        builder.ToTable("cart_product");

        builder.HasIndex(x => new { x.ProductId, x.CartId });
    }
}
