using FlowerShop.DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.DataAccess.Data.Configurations
{
    public class DecorationOrderDetailConfiguration : IEntityTypeConfiguration<DecorationOrderDetail>
    {
        public void Configure(EntityTypeBuilder<DecorationOrderDetail> builder)
        {
            builder
               .ToTable("DecorationsOrderDetails");
        }
    }
}