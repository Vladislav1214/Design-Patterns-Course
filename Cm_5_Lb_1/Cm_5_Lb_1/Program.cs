using Cm_5_Lb_1.Repositories;
using Cm_5_Lb_1.Readers;
using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using Cm_5_Lb_1.Parsers;
using Cm_5_Lb_1.Reporting;
using Cm_5_Lb_1.Validator;
using Cm_5_Lb_1.Core;


namespace Cm_5_Lb_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parsers = new Dictionary<string, ITransactionParser>
            {
                { ".csv", new CsvTransactionParser() },
                { ".json", new JsonTransactionParser() },
                { ".xml", new XmlTransactionParser() }
            };

            ITransactionValidator validator = new DefaultTransactionValidator();
            ITransactionRepository repo = new SqliteTransactionRepository();
            IProgressReporter reporter = new ConsoleProgressReporter();
            IImportSummaryWriter summaryWriter = new FileSummaryWriter();

            Console.WriteLine("=== Data Import Pipeline ===");

            while (true)
            {
                Console.WriteLine("\nВведіть шлях до файлу або URL (чи 'exit' для виходу):");
                Console.Write("> ");
                string source = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(source)) continue;
                if (source.ToLower() == "exit") break;

                IDataReader reader;
                if (source.StartsWith("http://") || source.StartsWith("https://"))
                {
                    reader = new NetworkStreamReader();
                }
                else
                {
                    reader = new LocalFileReader();
                }

                string extension = Path.GetExtension(source).ToLower();

                if (!parsers.ContainsKey(extension))
                {
                    Console.WriteLine($"[Помилка] Формат '{extension}' не підтримується системою!");
                    continue;
                }

                ITransactionParser selectedParser = parsers[extension];

                var processor = new ImportProcessor(reader, selectedParser, validator, repo, reporter);

                Console.WriteLine($"\nПочинаємо обробку: {source}");

                ImportResult result = processor.Process(source);

                summaryWriter.WriteSummary(result);
            }

            Console.WriteLine("Програму завершено. До побачення!");
        }
    }
}
