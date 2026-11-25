using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Cm_5_Lb_1.Parsers
{
    public class JsonTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(Stream stream)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<Transaction>>(stream, options)
                   ?? new List<Transaction>();
        }
    }
}
