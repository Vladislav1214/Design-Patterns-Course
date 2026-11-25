using Cm_5_Lb_1.Models;
using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Reporting
{
    public class FileSummaryWriter : IImportSummaryWriter
    {
        private readonly string _path;

        public FileSummaryWriter(string path)
        {
            _path = Path.GetFullPath(path);
        }

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

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, report);
                Console.WriteLine($"\nДетальний звіт збережено: {_path}");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                Console.WriteLine($"\nНе вдалося зберегти звіт: {ex.Message}");
                Console.WriteLine(report);
            }
        }
    }
}
