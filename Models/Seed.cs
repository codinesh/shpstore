using Groc.Areas.Identity.Data;
using Groc.AuthorizationHandlers;
using Groc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesItem.Models
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new GrocIdentityDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GrocIdentityDbContext>>()))
            {

                var passd = "HelloWorld@1";
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == "vemunoori@hotmail.com");
                var userId = user?.Id ?? 0;
                if (user == null)
                {
                    userId = await EnsureUser(serviceProvider, "Naveen V", "", 170, passd, "vemunoori@hotmail.com");
                }

                await EnsureRole(serviceProvider, userId, Constants.AdministratorsRole);

                user = await context.Users.FirstOrDefaultAsync(u => u.Email == "codinesh@live.com");
                userId = user?.Id ?? 0;
                if (user == null)
                {
                    userId = await EnsureUser(serviceProvider, "Dinesh", "", 127, passd, "codinesh@live.com");
                }

                await EnsureRole(serviceProvider, userId, Constants.AdministratorsRole);

                // Look for any Items.
                if (context.Inventory.Any())
                {
                    return;   // DB has been seeded
                }

                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SM KARNOOL RICE", PricePerUnit = 39.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWER OIL P(1L)", PricePerUnit = 123.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SM PRKARNOOL", PricePerUnit = 43.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SUGAR", PricePerUnit = 36.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "50 kg bag" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWER OIL(5L)", PricePerUnit = 600.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL P(1L)", PricePerUnit = 131.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWR OIL TIN(15L)", PricePerUnit = 1700.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "1" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL(5L)", PricePerUnit = 595.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "PILLSBURY WHEAT ATTA -5 KG", PricePerUnit = 270.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "6" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "ANURAG DEEPARADHANA OIL (900ML)", PricePerUnit = 150.00F, Category = ItemCategory.None, LotSize = "15" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL TIN(15KG)", PricePerUnit = 1811.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "1" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L ATTA WHEAT", PricePerUnit = 26.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SURF EXCEL BAR(800G)", PricePerUnit = 92.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "20" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "RAJAM GARLIC MIXTURE (1KG)", PricePerUnit = 199.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "15" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAGGI NOODLES MASALA(420G)", PricePerUnit = 67.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MYSORE SANDAL SOAP(450G)", PricePerUnit = 220.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "30" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BAMBINO PLAIN VERMICELLI(850G)", PricePerUnit = 77.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "30" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "AASHIRVAAD CHILLI POWDER(500G)", PricePerUnit = 150.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "32" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "DETTOL HYGIENE LIQ MULT-USE (500ML)", PricePerUnit = 193.00F, Category = ItemCategory.Medical, LotSize = "24" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SUNFEAST YIPPE MAG MASAL NOOD(360G)", PricePerUnit = 68.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "24" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "COLGATE STR THP 2X200 &1X100 (500G)", PricePerUnit = 209.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "24" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SANTOOR SOAP 4X150G(600G)", PricePerUnit = 180.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "24" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "WHEEL ACTIVE POWDER GREEN(1KG)", PricePerUnit = 53.00F, Category = ItemCategory.None, LotSize = "25" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "PARACHUTE COCONUT OIL(550ML)", PricePerUnit = 223.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "32" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWER OIL BOT(1L)", PricePerUnit = 123.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAAZA MANGO DRINK BOT(1.75L)", PricePerUnit = 90.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "WHISPER ULTRA CLEAN XL PLS (44PADS)", PricePerUnit = 430.00F, Category = ItemCategory.None, LotSize = "18" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SANTOOR SAND&TRM SOAP 4*125G (500G)", PricePerUnit = 150.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "30" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SPRITE BOTTLE(1.75L)", PricePerUnit = 85.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "DETTOL ORIGI LIQ HW PO B1G1F(750ML)", PricePerUnit = 218.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "6" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM RICE BRAN OIL POUCH(1L)", PricePerUnit = 123.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "10" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SUNFEAST DARK FANTA CHO FILLS(300G)", PricePerUnit = 120.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM GROUNDNUT OIL POUCH(1L)", PricePerUnit = 170.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SURF EXCEL MATICFRONT LOD LIQ(2LTR)", PricePerUnit = 390.00F, Category = ItemCategory.None, LotSize = "6" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BRITANNIA NUTRI CHOICE DIGES(1KG)", PricePerUnit = 169.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "5" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BRITANNIA GOODDY CAS COK BIS (600G)", PricePerUnit = 105.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "10" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BROOK BON RED L NATR CARE TEA(250G)", PricePerUnit = 130.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "ARIEL MATIC FRONT LOAD DET POW(4KG)", PricePerUnit = 1099.00F, Category = ItemCategory.None, LotSize = "2" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "VIJAYA PURE GHEE POUCH(1L)", PricePerUnit = 510.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SURF EXCEL EASY WASH DETERGN(1.5KG)", PricePerUnit = 207.00F, Category = ItemCategory.None, LotSize = "20" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L Raw HMT RICE", PricePerUnit = 54.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "HARPIC POWERPS ORG TOILET CLNR (1L)", PricePerUnit = 168.00F, Category = ItemCategory.None, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "ARIEL MATIC LIQUID DETERGENT-2LTR", PricePerUnit = 460.00F, Category = ItemCategory.None, LotSize = "6" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SUNFEAST MOM MG CAS N ALM BIS(600G)", PricePerUnit = 105.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "JAGGERY PREMIUM-900 GM", PricePerUnit = 80.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "18" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BOOST REFILL PACK(750G)", PricePerUnit = 351.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "HEALTHY HEART SUNFLOWER OIL(5L)", PricePerUnit = 575.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAMYPOKO PANTS EX AB 9-14KG L-74PCS", PricePerUnit = 1249.00F, Category = ItemCategory.None, LotSize = "3" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BROOKE BOND RED LABEL TEA(250G)", PricePerUnit = 105.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Inventory.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "VIJAYA GROUNDNUT OIL POUCH(1L)", PricePerUnit = 157.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });

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

        private static async Task<int> EnsureUser(IServiceProvider serviceProvider,
                              string name, string phoneNumber, int villaNumber, string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<GroceriesUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new GroceriesUser
                {
                    UserName = UserName,
                    Name = name,
                    VillaNumber = villaNumber,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      int uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<GroceriesUser>>();

            var user = await userManager.FindByIdAsync(uid.ToString());

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}