using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Text;

namespace Cm_5_Lb_1.Parsers
{
    public class CsvTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(string content)
    {
            var transactions = new List<Transaction>();

            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length <= 1)
            {
                return transactions;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                // Якщо рядок битий і в ньому менше 5 колонок - пропускаємо його
                if (columns.Length < 5)
                {
                    continue;
                }

                var transaction = new Transaction
                {
                    Id = columns[0].Trim(),

                    // DateTime.Parse формат "2026-09-14"
                    Date = DateTime.Parse(columns[1].Trim()),

                    Amount = decimal.Parse(columns[2].Trim(), CultureInfo.InvariantCulture),

                    Currency = columns[3].Trim(),
                    SenderAccount = columns[4].Trim()
                };

                transactions.Add(transaction);
            }

            return transactions;
        }
    }
}
