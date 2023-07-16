﻿using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class BeverageTranslationConfiguration : BaseConfiguration<BeverageTranslation>
{
    public override void Configure(EntityTypeBuilder<BeverageTranslation> builder)
    {
        base.Configure(builder);

        builder.ToTable("beverage_translation");

        builder.Property(x => x.Name)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Description)
           .HasMaxLength(256)
           .IsRequired();

        builder.HasKey(x => new { x.LanguageId, x.BeverageId });
    }
}
