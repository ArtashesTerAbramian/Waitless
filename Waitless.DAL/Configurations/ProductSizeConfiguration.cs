using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageSizeConfiguration : BaseConfiguration<ProductSize>
{
    public override void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_size");
    }
}
