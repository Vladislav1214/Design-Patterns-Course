using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string SenderAccount { get; set; }
    }
}
