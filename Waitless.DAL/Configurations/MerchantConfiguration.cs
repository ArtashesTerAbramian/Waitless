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
        
        builder.Property(x => x.Name)
            .HasMaxLength(256);

        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(x => x.Email)
            .HasMaxLength(256);

        builder.Property(x => x.Phone)
            .HasMaxLength(256);

        builder.HasIndex(x => x.UserName)
            .IsUnique();

        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}