using Cm_5_Lb_1.Models;
using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Reporting
{
    public class FileSummaryWriter : IImportSummaryWriter
    {
        public void WriteSummary(ImportResult result)
        {
            string report = "--- ПІДСУМКОВИЙ ЗВІТ ІМПОРТУ ---\n" +
                            $"Час завершення: {DateTime.Now}\n" +
                            $"Статус: {(result.IsSuccess ? "Успішно" : "Помилка")}\n" +
                            $"Додано в базу: {result.ProcessedCount} записів\n";

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                report += $"Опис помилки: {result.ErrorMessage}\n";
            }

            File.WriteAllText("import_summary.txt", report);
            Console.WriteLine("\nДетальний звіт збережено у файл 'import_summary.txt'.");
        }
    }
}
