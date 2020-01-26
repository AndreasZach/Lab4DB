using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lab4DB
{
    public partial class OrdersDbContext : DbContext
    {
        private string _connectionString;
        private string _connectionKey;
        private string _dbName;

        public OrdersDbContext(string connection, string key, string dbName)
        {
            _connectionString = connection;
            _connectionKey = key;
            _dbName = dbName;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(_connectionString, _connectionKey, databaseName: _dbName);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().OwnsOne(c => c.OrderStatus);
        }

    }
}
