using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations;

public class PermissionConfiguration : BaseConfiguration<Permission>
{
    public override void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permission");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(x => x.Value)
            .HasMaxLength(256);    }
}