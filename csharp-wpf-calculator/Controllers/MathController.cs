using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_wpf_calculator.Controllers
{
    public static class MathController
    {
        public static double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public static double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public static double Divide(double number1, double number2)
        {
            return number1 / number2;
        }

    }
}
