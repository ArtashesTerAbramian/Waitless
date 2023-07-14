using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class CoffeeTypeConfiguration : BaseConfiguration<BeverageType>
{
    public override void Configure(EntityTypeBuilder<BeverageType> builder)
    {
        base.Configure(builder);

        builder.ToTable("coffee_type");
    }
}
