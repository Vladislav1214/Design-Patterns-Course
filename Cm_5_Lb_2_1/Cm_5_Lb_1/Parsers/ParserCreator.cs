using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Parsers
{
    public abstract class ParserCreator
    {
        public abstract ITransactionParser CreateParser();
    }

    public class CsvParserCreator : ParserCreator
    {
        public override ITransactionParser CreateParser() => new CsvTransactionParser();
    }

    public class JsonParserCreator : ParserCreator
    {
        public override ITransactionParser CreateParser() => new JsonTransactionParser();
    }

    public class XmlParserCreator : ParserCreator
    {
        public override ITransactionParser CreateParser() => new XmlTransactionParser();
    }
}
