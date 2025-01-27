﻿


using Microsoft.EntityFrameworkCore;
using Pedidos.Core.Entities;

namespace Pedidos.Infraestucture
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        
    }
}
