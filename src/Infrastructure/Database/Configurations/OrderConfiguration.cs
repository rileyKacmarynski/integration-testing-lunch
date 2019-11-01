using Core.Entities.OrderEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(e => e.OrderId);
            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId");

            builder.Property(e => e.Total)
                .HasColumnName("Total")
                .HasColumnType("money");

            builder.OwnsMany<OrderItem>("_orderItems", eb =>
            {
                eb.ToTable("OrderItem", "dbo");

                eb.Property<int>("OrderId");
                eb.Property<int>("OrderItemId");
                eb.Property<int>("ProductId");

                eb.WithOwner()
                    .HasForeignKey("OrderId")
                    .HasConstraintName("FK_Order");

                eb.HasKey("OrderItemId");

                eb.Property(x => x.Total)
                    .HasColumnName("Total")
                    .HasColumnType("money")
                    .IsRequired();

                eb.Property(x => x.Quantity)
                    .HasColumnName("Quantity")
                    .IsRequired();
            });
        }
    }
}