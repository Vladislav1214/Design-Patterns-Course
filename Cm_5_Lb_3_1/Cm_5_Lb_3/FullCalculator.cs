using System;

namespace Cm_5_Lb_3
{
    public class FullCalculator : ICalculator
    {
        private readonly CallLog _log;
        public FullCalculator(CallLog log) { _log = log; }

        public double Add(double a, double b)
        {
            _log.Add($"FullCalculator: ({a} + {b})");
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            _log.Add($"FullCalculator: ({a} - {b})");
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            _log.Add($"FullCalculator: ({a} * {b})");
            return a * b;
        }

        public double Divide(double a, double b)
        {
            _log.Add($"FullCalculator: ({a} / {b})");
            if (b == 0) throw new DivideByZeroException("Ділення на нуль");
            return a / b;
        }
    }
}