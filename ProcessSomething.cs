using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestResult
{

    internal static class ProcessSomething
    {

        public static double Div(int n1, int n2)
        {
            var result = Calc.Div(n1, n2);

            if (result.IsSuccess)
                return result.Value;

            if(result.Error.InnerException is DivideByZeroException)
            {
                Console.WriteLine("Erro ao dividir por 0");
                return 0;
            }

            throw result.Error;
        }

        public static double Div2(int n1, int n2)
        {
            var result = Calc.Div2(n1, n2);

            if (result.IsSuccess)
                return result.Value;

            if (result.Error.InnerException is DivideByZeroException)
            {
                Console.WriteLine("Erro ao dividir por 0");
                return 0;
            }

            throw result.Error;
        }
    }
}
