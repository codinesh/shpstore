using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Groc.Areas.Identity.Data;
using Groc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Groc.Models.ViewModels.Order;

namespace Groc.Areas.Identity.Data
{   
    public class GrocIdentityDbContext : IdentityDbContext<GroceriesUser, IdentityRole<int>, int>
    {
        public DbSet<Inventory> Items { get; set; }
    
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLineItem> OrderLineItem {get;set;}

        public DbSet<UserMap> UserMap { get; set; }
    
        public DbSet<Availability> Availability {get;set;}

        public GrocIdentityDbContext(DbContextOptions<GrocIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(b => b.Name).HasColumnType("varchar(256)");
            builder.Entity<IdentityRole>().Property(b => b.NormalizedName).HasColumnType("varchar(256)");

            builder.Entity<GroceriesUser>().Property(b => b.Email).HasColumnType("varchar(256)");
            builder.Entity<GroceriesUser>().Property(b => b.NormalizedEmail).HasColumnType("varchar(256)");
            builder.Entity<GroceriesUser>().Property(b => b.NormalizedUserName).HasColumnType("varchar(256)");
            builder.Entity<GroceriesUser>().Property(b => b.UserName).HasColumnType("varchar(256)");
            builder.Entity<GroceriesUser>().Property(b => b.Email).HasColumnType("varchar(256)");

        }

        public DbSet<Groc.Models.ViewModels.Order.OrderViewModel> OrderViewModel { get; set; }
    }
}
