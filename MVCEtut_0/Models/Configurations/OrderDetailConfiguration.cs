using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEtut_0.Models.Entities;

namespace MVCEtut_0.Models.Configurations
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.HasIndex(x=> new {x.OrderId,x.ProductId}).IsUnique();
        }
    }
}
