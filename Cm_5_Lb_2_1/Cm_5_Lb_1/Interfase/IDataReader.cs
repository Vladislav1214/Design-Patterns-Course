using System;
using System.IO;

namespace Cm_5_Lb_1.Interfase
{
    public interface IDataReader
    {
        bool Exists(string source);

        Stream Open(string source);
    }
}
