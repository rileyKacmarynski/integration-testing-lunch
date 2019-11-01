using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.CartEntity;
using Core.Entities.OrderEntity;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IThingShopDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}