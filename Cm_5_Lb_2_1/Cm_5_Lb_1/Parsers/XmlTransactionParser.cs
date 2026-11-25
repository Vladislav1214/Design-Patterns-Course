using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cm_5_Lb_1.Parsers
{
    public class XmlTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(List<Transaction>), new XmlRootAttribute("Transactions"));

            return (serializer.Deserialize(stream) as List<Transaction>) ?? new List<Transaction>();
        }
    }
}
