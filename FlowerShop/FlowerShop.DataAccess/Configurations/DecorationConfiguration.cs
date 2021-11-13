namespace FlowerShop.Configurations
{
    using FlowerShop.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DecorationConfiguration : IEntityTypeConfiguration<Decoration>
    {
        public void Configure(EntityTypeBuilder<Decoration> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Roles)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(x => x.IsAvailable)
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasPrecision(14, 2)
                .IsRequired();
        }
    }
}