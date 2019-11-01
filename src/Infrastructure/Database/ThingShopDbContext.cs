using Core.Entities;
using Core.Entities.CartEntity;
using Core.Entities.OrderEntity;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ThingShopDbContext : DbContext, IThingShopDbContext
    {
        public ThingShopDbContext(DbContextOptions<ThingShopDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ThingShopDbContext).Assembly);
        }
    }
}