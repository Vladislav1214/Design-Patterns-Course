using Cm_5_Lb_1.Repositories;
using Cm_5_Lb_1.Readers;
using Cm_5_Lb_1.Interfase;
using Cm_5_Lb_1.Models;
using Cm_5_Lb_1.Parsers;
using Cm_5_Lb_1.Reporting;
using Cm_5_Lb_1.Validator;
using Cm_5_Lb_1.Core;
using System.Text;
using System.IO;
using System;

namespace Cm_5_Lb_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var connectionString = "transactions.db";

            ITransactionValidator validator = new DefaultTransactionValidator();
            ITransactionRepository repo = new SqliteTransactionRepository(connectionString);

            // Використовуємо Singleton для логера
            IProgressReporter reporter = ConsoleProgressReporter.GetInstance();
            IImportSummaryWriter summaryWriter = new FileSummaryWriter("../../../import_summary.txt");

            Console.WriteLine("Data Import Pipeline");

            while (true)
            {
                Console.WriteLine("\nВведіть шлях до файлу або URL (чи 'exit' для виходу):");
                Console.Write("> ");
                string? source = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(source)) continue;
                if (source.ToLower() == "exit") break;

                try
                {
                    IDataReader reader;
                    if (source.StartsWith("http://") || source.StartsWith("https://"))
                    {
                        reader = new NetworkStreamReader();
                    }
                    else
                    {
                        reader = new LocalFileReader();
                    }

                    // 1. Використовуємо Factory Method для отримання парсера
                    ITransactionParser selectedParser = ParserProvider.GetParser(source);

                    // 2. Використовуємо Builder для збирання процесора
                    var processor = new ImportProcessorBuilder()
                        .UseReader(reader)
                        .UseParser(selectedParser)
                        .UseValidator(validator)
                        .UseRepository(repo)
                        .UseReporter(reporter)
                        .Build();

                    Console.WriteLine($"\nПочинаємо обробку: {source}");

                    ImportResult result = processor.Process(source);

                    summaryWriter.WriteSummary(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Помилка конфігурації] {ex.Message}");
                }
            }

            Console.WriteLine("Програму завершено. До побачення!");
        }
    }
}