
using Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=localDBFiles/localdb.db");
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasDiscriminator<string>("OrderType")
                .HasValue<Order>("Order").HasValue<ReturnOrder>("Return");
            modelBuilder.Entity<Order>().HasMany(o=>o.OrderItems).WithOne().HasForeignKey(oi=>oi.OrderId);
            modelBuilder.Entity<Product>().HasMany<OrderItem>().WithOne(oi=>oi.Product).HasForeignKey(oi=>oi.ProductId);
            modelBuilder.Entity<Product>().OwnsOne(p => p.Price);


            modelBuilder.Entity<User>().HasMany<Order>().WithOne().HasForeignKey(o=>o.UserId);
            modelBuilder.Entity<User>().OwnsOne(p=>p.Address);

        }

    }
}
