using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Validator
{
    public class DefaultTransactionValidator : ITransactionValidator 
    {
        public IEnumerable<Transaction> Validate(IEnumerable<Transaction> transactions)
        {
            return transactions.Where(t =>
                t.Amount > 0 &&
                !string.IsNullOrWhiteSpace(t.Id) &&
                !string.IsNullOrWhiteSpace(t.Currency) &&
                !string.IsNullOrWhiteSpace(t.SenderAccount) &&
                t.Date != default(DateTime)
            );
        }
    }
}
