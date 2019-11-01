using Core.Entities.CartEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.cs
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart", "dbo");

            builder.HasKey(e => e.CartId);
            builder.Property(e => e.CartId)
                .UseIdentityColumn()
                .HasColumnName("CartId");

            builder.OwnsMany<CartItem>("_cartItems", eb =>
            {
                eb.ToTable("CartItem", "dbo");

                eb.Property<int>("ProductId");
                eb.Property<int>("CartId");
                eb.Property<int>("CartItemId");

                eb.WithOwner()
                    .HasForeignKey("CartId")
                    .HasConstraintName("FK_Cart");

                eb.HasKey("CartItemId");

                eb.Property(x => x.Price)
                    .HasColumnName("Price")
                    .HasColumnType("money");

                eb.Property(x => x.Quantity)
                    .HasColumnName("Quantity");
            });
        }
    }
}