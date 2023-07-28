using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations
{
    public class UserPasswordResetConfiguration : BaseConfiguration<UserPasswordReset>
    {
        public override void Configure(EntityTypeBuilder<UserPasswordReset> builder)
        {
            base.Configure(builder);

            builder.ToTable("user_password_reset");

            builder.Property(x => x.Token)
                .HasMaxLength(128);
        }
    }
}
