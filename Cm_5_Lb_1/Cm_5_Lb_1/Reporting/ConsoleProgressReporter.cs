using Cm_5_Lb_1.Interfase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cm_5_Lb_1.Reporting
{
    internal class ConsoleProgressReporter : IProgressReporter
    {
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
