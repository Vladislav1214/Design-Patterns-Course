using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cm_5_Lb_1.Parsers
{
    internal class XmlTransactionParser : ITransactionParser
    {
        public IEnumerable<Transaction> Parse(string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>), new XmlRootAttribute("Transactions"));

            using (var reader = new StringReader(content))
            {
                return (serializer.Deserialize(reader) as List<Transaction>) ?? new List<Transaction>();
            }
        }
    }
}
