using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Interfase
{
    public interface IDataReader
    {
        bool Exists(string source);
        string Read(string source);
    }
}
