using System;
using System.Collections.Generic;
using Cm_5_Lb_1.Models;

namespace Cm_5_Lb_1.Interfase
{
    public interface ITransactionRepository
    {
        int Save(IEnumerable<Transaction> items);
    }
}
