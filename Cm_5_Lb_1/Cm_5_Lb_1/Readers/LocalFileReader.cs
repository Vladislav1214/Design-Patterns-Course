using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.IO;

namespace Cm_5_Lb_1.Readers
{
    public class LocalFileReader : IDataReader
    {
        public bool Exists(string source)
        {
            return File.Exists(source);
        }

        public string Read(string source)
        {
            return File.ReadAllText(source);
        }
    }
}
