using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class ProductSizeConfiguration : BaseConfiguration<ProductSize>
{
    public override void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        base.Configure(builder);

        builder.ToTable("product_size");
    }
}
