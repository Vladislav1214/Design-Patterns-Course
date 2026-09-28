using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Readers
{
    public class NetworkStreamReader: IDataReader
    {
        public bool Exists(string source)
        {
            return true;
        }

        public string Read(string source)
        {
            return " ";
        }
    }
}
