using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarketCore
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=stockmarketsimulator;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tradable>()
                .HasIndex(x => x.Ticker)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<Order> BuyOrders => Orders.Where(x => x.Type == OrderType.Buy);
        public IQueryable<Order> SellOrders => Orders.Where(x => x.Type == OrderType.Sell);

        public  DbSet<Order> Orders { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Tradable> Tradables { get; set; }
    }
}
