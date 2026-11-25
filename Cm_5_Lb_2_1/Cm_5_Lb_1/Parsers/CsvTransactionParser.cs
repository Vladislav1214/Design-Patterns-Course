using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Cm_5_Lb_1.Parsers
{
    public class CsvTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(Stream stream)
        {
            var result = new List<Transaction>();

            using var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, leaveOpen: true);

            reader.ReadLine();

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] columns = line.Split(',');
                if (columns.Length < 5) continue;

                if (!DateTime.TryParse(columns[1].Trim(), CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out var date)) continue;

                if (!decimal.TryParse(columns[2].Trim(), NumberStyles.Number,
                                      CultureInfo.InvariantCulture, out var amount)) continue;

                result.Add(new Transaction
                {
                    Id = columns[0].Trim(),
                    Date = date,
                    Amount = amount,
                    Currency = columns[3].Trim(),
                    SenderAccount = columns[4].Trim()
                });
            }

            return result;
        }
    }
}
