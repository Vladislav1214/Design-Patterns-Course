using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cm_5_Lb_1.Repositories
{
    public class SqliteTransactionRepository : ITransactionRepository
    {
        private const int BatchSize = 1000;

        private readonly string _connectionString;

        public SqliteTransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Save(IEnumerable<Transaction> transactions)
        {
            using var context = new AppDbContext(_connectionString);
            context.Database.EnsureCreated();

            using var dbTransaction = context.Database.BeginTransaction();

            int total = 0;

            foreach (var batch in transactions.Chunk(BatchSize))
            {
                context.Transactions.AddRange(batch);
                context.SaveChanges();
                context.ChangeTracker.Clear();
                total += batch.Length;
            }

            dbTransaction.Commit();
            return total;
        }
    }
}
