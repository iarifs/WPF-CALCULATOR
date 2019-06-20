using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_App
{
    public interface ICalculator
    {
        string Calculate();
    }

    public class StandardCalculator : ICalculator
    {
        public string Calculate()
        {
            throw new NotImplementedException();
        }
    }

    public class DecimalCalculator : ICalculator
    {
        public string Calculate()
        {
            throw new NotImplementedException();
        }
    }

    public class CalculatorFactory
    {
        public static ICalculator Create(string param)
        {
            if (param == "standard")
            {
                return new StandardCalculator();
            }

            return null;
        }
    }

    class Class1
    {
    }
}
