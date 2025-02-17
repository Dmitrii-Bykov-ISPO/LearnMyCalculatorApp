using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMyCalculatorApp1
{
    public class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }
        public double SIN(double x)
        {
            return Math.Sin(x);
        }

        public double SIN(double x)
        {
            return Math.Sin(x);
        }

        public double? Divide(double x, double y)
        {
            try
            {
                return x / y;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на 0");
                return null;
            }
        }
        public double? ctg(double x)
        {
            try
            {
                return 1 / Math.Tan(x);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на 0");
                return null;
            }
        }

    }
}