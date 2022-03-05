using System;
using Common.Interfaces;
using Common.AbstractClasses;

namespace Common.Interfaces
{
    public interface ISalaryCalculator
    {
        public double CalculateSalary(Employee employee);
    }
}
