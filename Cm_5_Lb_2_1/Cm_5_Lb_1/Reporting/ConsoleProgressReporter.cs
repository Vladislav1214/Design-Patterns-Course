using Cm_5_Lb_1.Interfase;
using System;

namespace Cm_5_Lb_1.Reporting
{
    public class ConsoleProgressReporter : IProgressReporter
    {
        private static readonly ConsoleProgressReporter _instance = new ConsoleProgressReporter();

        private ConsoleProgressReporter() { }

        public static ConsoleProgressReporter GetInstance() => _instance;

        public void ReportProgress(int percentage)
        {
            Console.Write($"\r[Прогрес]: {percentage}% завершено...");

            if (percentage == 100)
            {
                Console.WriteLine();
            }
        }
    }
}
