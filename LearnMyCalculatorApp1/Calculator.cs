using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMyCalculatorApp1
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int? Divide(int x, int y)
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

    }
}