using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_3
{
    public class CalculatorApp
    {
        private readonly ICalculator _calc;
        private readonly CallLog _log;

        public CalculatorApp(ICalculator calc, CallLog log)
        {
            _calc = calc;
            _log = log;
        }

        public void Run()
        {
            PrintHeader();

            while (true)
            {
                Console.Write("> ");
                string? line = Console.ReadLine();
                if (line == null || line.Trim().ToLower() == "q") break;

                if (!TryParseExpression(line, out double a, out string op, out double b))
                {
                    Console.WriteLine("Неправильний формат. Приклад: 3.5 * 2\n");
                    continue;
                }

                Execute(a, op, b);
                PrintLog();
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("LightCalculator (Proxy) + FullCalculator");
            Console.WriteLine("Введіть вираз у форматі: число оператор число (наприклад: 5 + 0)");
            Console.WriteLine("Оператори: + - * /     Вихід: q\n");
        }

        private void Execute(double a, string op, double b)
        {
            try
            {
                double result = op switch
                {
                    "+" => _calc.Add(a, b),
                    "-" => _calc.Subtract(a, b),
                    "*" => _calc.Multiply(a, b),
                    "/" => _calc.Divide(a, b),
                    _ => throw new ArgumentException($"Невідомий оператор '{op}'")
                };
                Console.WriteLine($"Результат: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        private void PrintLog()
        {
            Console.WriteLine("Що було викликано:");
            foreach (var entry in _log.Flush())
                Console.WriteLine($"  • {entry}");
            Console.WriteLine();
        }

        private static bool TryParseExpression(string line, out double a, out string op, out double b)
        {
            a = b = 0;
            op = "";

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3) return false;

            op = parts[1];
            return TryParseNumber(parts[0], out a) && TryParseNumber(parts[2], out b);
        }

        private static bool TryParseNumber(string s, out double value) =>
            double.TryParse(s.Replace(',', '.'), NumberStyles.Float,
                            CultureInfo.InvariantCulture, out value);
    }
}
