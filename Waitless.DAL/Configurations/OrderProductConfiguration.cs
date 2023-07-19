using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Waitless.DAL.Models;

namespace Waitless.DAL.Configurations
{
    public class OrderProductConfiguration : BaseConfiguration<OrderProduct>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            base.Configure(builder);

            builder.ToTable("order_product");

            builder.HasIndex(x => new { x.OrderId, x.ProductId });
        }

    }
}
