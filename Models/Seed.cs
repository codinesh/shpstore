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
                if (context.Inventory.Any())
                {
                    return;   // DB has been seeded
                }

                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "AASHIRVAAD WHEAT ATTA MP(2KG)", PricePerUnit = 109.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "6" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "AASHIRVAAD WHEAT ATTA MP RED (10KG)", PricePerUnit = 490.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "3" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "AASHIRVAAD WHEAT MP RED ATTA(5KG)", PricePerUnit = 270.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "6" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "TATA SALT (1KG)", PricePerUnit = 20.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "20" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "AASHIRVAAD CHILLI POWDER(500G)", PricePerUnit = 150.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "32" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLDY CAKE TAMRIND-1KG", PricePerUnit = 296.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "30" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLDY CAKE TAMRIND(500G)", PricePerUnit = 149.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SWASTIK AGMARK MIRCH POWDER-500G", PricePerUnit = 160.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "20" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BAMBINO PLAIN VERMICELLI(850G)", PricePerUnit = 77.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "30" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BROOKE BOND RED LABEL TEA(250G)", PricePerUnit = 105.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BROOKE BOND RED LABEL TEA(500G)", PricePerUnit = 205.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAGGI NOODLES MASALA(420G)", PricePerUnit = 67.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAGGI MASALA NOODLES(560G)", PricePerUnit = 91.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "36" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "PARLE KRACKJACK BIS(200G)", PricePerUnit = 30.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "72" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SPRITE BOTTLE(1.75L)", PricePerUnit = 85.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "THUMS UP (1.75L)", PricePerUnit = 85.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL P(1L)", PricePerUnit = 131.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL(5L)", PricePerUnit = 595.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "VIJAYA GROUNDNUT OIL POUCH(1L)", PricePerUnit = 157.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "HEALTHY HEART SUNFLOWER OIL(5L)", PricePerUnit = 575.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "GOLD DROP SUNFLOWER OIL TIN(15KG)", PricePerUnit = 1811.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "1" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BROOK BON RED L NATR CARE TEA(250G)", PricePerUnit = 130.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWER OIL P(1L)", PricePerUnit = 123.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "JERSEY PANEER PREMIUM-500GM", PricePerUnit = 240.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "10" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWER OIL(5L)", PricePerUnit = 600.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "4" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "RAJAM GARLIC MIXTURE (1KG)", PricePerUnit = 199.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "6" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "FREEDOM SUNFLOWR OIL TIN(15L)", PricePerUnit = 1700.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "1" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SUNFEAST YIPPE MAG MASAL NOOD(360G)", PricePerUnit = 68.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "BRITANNIA NUTRI CHOICE DIGES(1KG)", PricePerUnit = 169.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SUNFEAST MOM MG CAS N ALM BIS(600G)", PricePerUnit = 105.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAAZA MANGO DRINK BOT(1.75L)", PricePerUnit = 90.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "12" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SWAAD SUNFLOWER OIL(1L)", PricePerUnit = 120.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "16" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "DETTOL ORIGINAL HANDWAS PUMP(200ML)", PricePerUnit = 99.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MYSORE SANDAL SOAP(450G)", PricePerUnit = 220.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "30" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SANTOOR SUPER SAVER PACK SOAP(360G)", PricePerUnit = 100.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "48" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "WHEEL ACTIVE POWDER GREEN(1KG)", PricePerUnit = 53.00F, Category = ItemCategory.None, LotSize = "50" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SURF  EXCEL BAR(800G)", PricePerUnit = 94.00F, Category = ItemCategory.None, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SANTOOR SOAP 4X150G(600G)", PricePerUnit = 180.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "SANTOOR SAND&TRM SOAP 4*125G (500G)", PricePerUnit = 140.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "36" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "ANURAG DEEPARADHANA OIL (900ML)", PricePerUnit = 150.00F, Category = ItemCategory.None, LotSize = "36" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "DETTOL ORIG HANDWASH P 3X175(525ML)", PricePerUnit = 134.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "COLGATE STR THP 2X200 &1X100 (500G)", PricePerUnit = 209.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "24" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "DETTOL ORIGINAL SOAP B4G1F(4X125G)", PricePerUnit = 200.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "36" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "PARACHUTE COCONUT OIL(550ML)", PricePerUnit = 223.00F, Category = ItemCategory.BeautyAndGrooming, LotSize = "36" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAMYPOKO PANTS EX AB 7-12KG M-87PCS", PricePerUnit = 1249.00F, Category = ItemCategory.None, LotSize = "4" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "MAMYPOKO PANTS EX AB 9-14KG L-74PCS", PricePerUnit = 1249.00F, Category = ItemCategory.None, LotSize = "4" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SM PRKARNOOL", PricePerUnit = 43.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SM KARNOOL RICE", PricePerUnit = 39.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L SUGAR", PricePerUnit = 36.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "50 kg bag" });
                context.Items.AddRange(new Inventory { CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, CreatedByUser = 2, IsDeleted = false, Name = "L ATTA WHEAT", PricePerUnit = 26.00F, Category = ItemCategory.FoodAndNutrition, LotSize = "25 kg bag" });

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