using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesItem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GrocIdentityDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GrocIdentityDbContext>>()))
            {
                // Look for any Items.
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.Items.AddRange(
                    new Inventory
                    {
                        Name = "Tomatoes",
                        PricePerUnit = 20,
                        UnitType = UnitType.Kilo,
                    }
                );

                context.UserMap.AddRange(
                    new UserMap
                    {
                        VillaNumber = 127, 
                        PhoneNumber = "9493370092",
                        Email = "codinesh@live.com"
                    },
                    new UserMap
                    {
                        VillaNumber = 170, 
                        PhoneNumber = "9908635000",
                        Email = "vemunoori@gmail.com"
                    }
                );


                context.SaveChanges();
            }
        }
    }
}