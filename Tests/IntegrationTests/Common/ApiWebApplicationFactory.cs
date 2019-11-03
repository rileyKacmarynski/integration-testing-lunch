using System;
using System.Linq;
using System.Net.Http;
using Core.Interfaces;
using Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Common
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services => {
                // remove already registered dbcontext and replace it with in-memory
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ThingShopDbContext>));
                if(descriptor != null) services.Remove(descriptor);

                services.AddDbContext<ThingShopDbContext>((options, context) => {
                    context.UseInMemoryDatabase("IntegrationTestDb");
                });

                #region If we want to just seed the in memory db
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ThingShopDbContext>();

                    try
                    {
                        await Utils.SeedDatabase(db);
                    }
                    catch (Exception ex)
                    {
                        // handle exception
                    }
                }
                #endregion

                #region If we want to seed a test database we can do that here
                // var sp = services.BuildServiceProvider();
                // using(var scope = sp.CreateScope())
                // {
                //     var scopedServices = scope.ServiceProvider;
                //     var db = scopedServices.GetRequiredService<ThingShopDbContext>();

                //     db.Database.Migrate();

                //     try 
                //     {
                //         // run code to seed database here
                //     }
                //     catch(Exception ex)
                //     {
                //         // handle exception
                //     }
                // }
                #endregion

            });

        }

        protected override void ConfigureClient(HttpClient client)
        {
            // configure client here
        }
    }
}