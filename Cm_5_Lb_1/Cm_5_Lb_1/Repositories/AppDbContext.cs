using Microsoft.EntityFrameworkCore;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=transactions.db");
        }
    }
}
