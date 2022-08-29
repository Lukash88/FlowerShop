namespace FlowerShop.DataAccess.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DecorationOrderDetailConfiguration : IEntityTypeConfiguration<DecorationOrderDetail>
    {
        public void Configure(EntityTypeBuilder<DecorationOrderDetail> builder)
        {
            builder
               .ToTable("DecorationsOrderDetails");
        }
    }
}