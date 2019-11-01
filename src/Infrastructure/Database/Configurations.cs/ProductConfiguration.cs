using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.cs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "dbo");

            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.ProductId)
                .UseIdentityColumn()
                .HasColumnName("ProductId");

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnName("Price")
                .HasColumnType("money")
                .IsRequired();
        }
    }
}