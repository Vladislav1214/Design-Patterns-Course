using Cm_5_Lb_1.Interfase;
using System;
using System.IO;

namespace Cm_5_Lb_1.Readers
{
    public class LocalFileReader : IDataReader
    {
        public bool Exists(string source)
        {
            return File.Exists(source);
        }

        public Stream Open(string source)
        {
            return new FileStream(
                source,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 4096,
                FileOptions.SequentialScan);
        }
    }
}
