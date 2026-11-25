using System;
using System.Globalization;
using System.Text;

namespace Cm_5_Lb_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var log = new CallLog();
            ICalculator full = new FullCalculator(log);
            ICalculator calc = new LightCalculator(full, log);

            new CalculatorApp(calc, log).Run();
        }
    }
}
