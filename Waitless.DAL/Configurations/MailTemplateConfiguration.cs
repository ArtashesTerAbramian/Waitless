using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations
{
    public class MailTemplateConfiguration : BaseConfiguration<MailTemplate>
    {
        public override void Configure(EntityTypeBuilder<MailTemplate> builder)
        {
            base.Configure(builder);

            builder.ToTable("mail_template");

            builder.Property(x => x.HtmlBody)
                .IsRequired();

            builder.Property(x => x.Subject)
                .IsRequired();
        }

    }
}
