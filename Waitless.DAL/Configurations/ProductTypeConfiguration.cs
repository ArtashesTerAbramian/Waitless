using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class BeverageTypeConfiguration : BaseConfiguration<ProductType>
{
    public override void Configure(EntityTypeBuilder<ProductType> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_type");
    }
}