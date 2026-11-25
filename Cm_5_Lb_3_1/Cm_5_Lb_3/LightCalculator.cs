using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm_5_Lb_3
{
    public class LightCalculator : ICalculator
    {
        private readonly ICalculator _full;
        private readonly CallLog _log;

        public LightCalculator(ICalculator full, CallLog log)
        {
            _full = full;
            _log = log;
        }

        public double Add(double a, double b)
        {
            if (b == 0) return Handled("A + 0 = A", a);
            if (a == 0) return Handled("0 + A = A", b);
            return Delegate(() => _full.Add(a, b));
        }

        public double Subtract(double a, double b)
        {
            if (b == 0) return Handled("A - 0 = A", a);
            if (a == 0) return Handled("0 - A = -A", -b);
            return Delegate(() => _full.Subtract(a, b));
        }

        public double Multiply(double a, double b)
        {
            if (a == 0) return Handled("0 * A = 0", 0);
            if (b == 0) return Handled("A * 0 = 0", 0);
            return Delegate(() => _full.Multiply(a, b));
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                _log.Add("LightCalculator: правило A / 0 → виняток");
                throw new DivideByZeroException("Ділення на нуль");
            }
            if (a == 0) return Handled("0 / B = 0", 0);
            return Delegate(() => _full.Divide(a, b));
        }

        private double Handled(string rule, double result)
        {
            _log.Add($"LightCalculator: правило {rule}");
            return result;
        }

        private double Delegate(Func<double> call)
        {
            _log.Add("LightCalculator: правил немає");
            return call();
        }
    }
}
