using Microsoft.AspNetCore.Mvc;
using StudentDemo.Models;
using System.Runtime.CompilerServices;

namespace StudentDemo.DataAccess
{
    public class CalculatorService: ICalculatorService<Calculator>
    {
        public static List<Calculator> calculator = new List<Calculator>
        {
            new Calculator
            {
               Number1 = 10,
               Number2 = 20,
               Result = 30
            }
        };
        public List<Calculator> GetAllData()
        {
            return calculator;
        }

        public Calculator Add(Calculator model)
        {
            model.Result = model.Number1 + model.Number2;
            calculator.Add(model);
            return model;
        }
        public Calculator Subtract(Calculator model)
        {
            model.Result = model.Number1 - model.Number2;
            calculator.Add(model);
            return model;
        }
        public Calculator Multiple(Calculator model)
        {
            model.Result = model.Number1 * model.Number2;
            calculator.Add(model);
            return model;
        }
        public Calculator Divide(Calculator model)
        {
            if (model.Number2 != 0)
                model.Result = model.Number1 / model.Number2;
            else
                model.Result = 0;

            calculator.Add(model);
            return model;
        }
    }
}
