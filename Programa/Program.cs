using System;
using System.Collections.Generic;
using Common.Interfaces;
using Common.Utility;
using Common.AbstractClasses;
using Common.Entities;
using Common.Exceptions;
using Programa.Prototype1.Modelo.Utility;

namespace Programa
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hi, please give me the name of the file you want to use");
                string fileName = Console.ReadLine();

                IParserBuilder parserBuilder = new NaiveBuilder();
                ISourceParser sourceParser = parserBuilder.Build();

                //Obtener que archivo quiero utilizar
                IList<Employee> employeeCollection = sourceParser.Parse(fileName);

                //Calculamos el salario y lo imprimimos
                ISalaryCalculator salaryCalculator = new SalaryCalculator();
                foreach (Employee employee in employeeCollection)
                {
                    double salary = salaryCalculator.CalculateSalary(employee);
                    Console.WriteLine($"The amount to pay {employee.Name} is:{salary} USD");
                }

                Console.WriteLine("End of the execution, have a nice day");
                Console.ReadKey();
            }
            catch(FileValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
