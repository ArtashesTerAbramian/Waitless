using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class UserSessionConfiguration : BaseConfiguration<UserSession>
{
    public override void Configure(EntityTypeBuilder<UserSession> builder)
    {
        base.Configure(builder);

        builder.ToTable("user_session");

        builder.Property(x => x.Token)
            .HasMaxLength(256);

        builder.HasIndex(x => x.UserId);
    }
}