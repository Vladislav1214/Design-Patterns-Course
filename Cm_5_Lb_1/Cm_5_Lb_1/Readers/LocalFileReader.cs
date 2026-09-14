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
        public string Read(string source)
        {
            if (File.Exists(source))
            {
                string content = File.ReadAllText(source);
                return content;
            }

            throw new Exception($"{typeof(LocalFileReader)} Файл не знайдено: {source}");
        }
    }
}
