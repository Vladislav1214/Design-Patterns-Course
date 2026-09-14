using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Parsers
{
    public class JsonTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(string content)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<Transaction>>(content, options) ?? new List<Transaction>();
        }
    }
}
