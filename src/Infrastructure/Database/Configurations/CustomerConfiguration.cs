using Core.Entities;
using Core.Entities.CartEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");
            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.CustomerId)
                .UseIdentityColumn()
                .HasColumnName("CustomerId");

            builder.Property(e => e.Username)
                .HasColumnName("Username")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property<int>("CartId");
        }
    }
}