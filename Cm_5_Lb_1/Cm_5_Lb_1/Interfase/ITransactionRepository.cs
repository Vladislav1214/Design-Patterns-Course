using System;
using System.Collections.Generic;
using System.Text;
using Cm_5_Lb_1.Models;

namespace Cm_5_Lb_1.Interfase
{
    internal interface ITransactionRepository
    {
        void Save(IEnumerable<Transaction> items);
    }
}
