using Waitless.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Waitless.DAL.Configurations;

public class OrderConfiguration : BaseConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.ToTable("orders");

        builder.Property(x => x.Instruction)
            .HasMaxLength(256);

        builder.Property(x => x.TotalPrice)
            .HasColumnType("numeric(18,2)") 
            .IsRequired();

        builder.Property(x => x.AddressId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

         /*builder
             .HasMany(o => o.CoffeeIds)
            .WithMany()  // Configure the many-to-many relationship with the appropriate navigation properties.
            .UsingEntity(j => j.ToTable("OrderCoffee")); */
        
        builder.HasIndex(x => new { x.AddressId, x.UserId });
    }
}
