using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Repositories
{
    public class SqliteTransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public SqliteTransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(IEnumerable<Transaction> transactions)
        {
            using var context = new AppDbContext(_connectionString);

            context.Database.EnsureCreated();

            context.Transactions.AddRange(transactions);

            context.SaveChanges();
        }
    }
}
