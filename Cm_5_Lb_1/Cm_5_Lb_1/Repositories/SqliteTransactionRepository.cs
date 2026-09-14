using System;
using System.Collections.Generic;
using System.Text;
using Cm_5_Lb_1.Models;
using Cm_5_Lb_1.Interfase;

namespace Cm_5_Lb_1.Repositories
{
    internal class SqliteTransactionRepository : ITransactionRepository
    {
        public void Save(IEnumerable<Transaction> transactions)
        {
            using var context = new AppDbContext();

            context.Database.EnsureCreated();

            context.Transactions.AddRange(transactions);

            context.SaveChanges();
        }
    }
}
