using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class MerchantConfiguration : BaseConfiguration<Merchant>
{
    public override void Configure(EntityTypeBuilder<Merchant> builder)
    {
        base.Configure(builder);

        builder.ToTable("merchant");
    }
}