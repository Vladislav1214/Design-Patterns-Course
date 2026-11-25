using Microsoft.EntityFrameworkCore;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Repositories
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(string connectionString = "transactions.db")
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_connectionString}");
        }
    }
}
