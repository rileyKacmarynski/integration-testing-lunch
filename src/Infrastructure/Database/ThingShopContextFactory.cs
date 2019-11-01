using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class ThingShopContextFactory : DesignTimeDbContextFactory<ThingShopDbContext>
    {
        protected override ThingShopDbContext CreateNewInstance(DbContextOptions<ThingShopDbContext> options)
        {
            return new ThingShopDbContext(options);
        }
    }
}