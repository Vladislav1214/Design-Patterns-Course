using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.IO;

namespace Cm_5_Lb_1.Parsers
{
    public static class ParserProvider
    {
        private static readonly Dictionary<string, ParserCreator> _creators =
            new(StringComparer.OrdinalIgnoreCase)
            {
                [".csv"] = new CsvParserCreator(),
                [".json"] = new JsonParserCreator(),
                [".xml"] = new XmlParserCreator(),
            };

        public static void Register(string extension, ParserCreator creator)
        {
            _creators[extension] = creator;
        }

        public static ITransactionParser GetParser(string filePath)
        {
            string path = Uri.TryCreate(filePath, UriKind.Absolute, out var uri)
                          && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                ? uri.AbsolutePath
                : filePath;

            string extension = Path.GetExtension(path);

            if (_creators.TryGetValue(extension, out var creator))
            {
                return creator.CreateParser();
            }

            throw new NotSupportedException($"Формат '{extension}' не підтримується системою!");
        }
    }
}
