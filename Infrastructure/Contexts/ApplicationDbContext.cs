
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlite("Data Source=../Infrastructure/localDBFiles/localdb.db");
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
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();

        }

    }
}
