using System;
using System.Collections.Generic;
using Common.Interfaces;
using Common.AbstractClasses;
using Common.Enums;

namespace Common.Utility
{
    public class SalaryCalculator : ISalaryCalculator
    {
        public SalaryCalculator()
        {
        }

        public double CalculateSalary(Employee employee)
        {
            IList<IWorkedSchedule> employeeWorkedSchedules = employee.WorkedSchedule;
            double salary = 0;
            foreach(IWorkedSchedule workedSchedule in employeeWorkedSchedules)
            {
                salary += CalculateScheduleValue(workedSchedule);
            }
            return salary;
        }

        private double CalculateScheduleValue(IWorkedSchedule workedSchedule)
        {
            double hourlyRate;
            if(workedSchedule.WorkingDay == WorkingDays.SA || workedSchedule.WorkingDay == WorkingDays.SU)
            {
                hourlyRate = GetWeekendHourlyRate(workedSchedule.WorkingTimeGroup);
            }
            else
            {
                hourlyRate = GetWeekdayHourlyRat(workedSchedule.WorkingTimeGroup);
            }

            return workedSchedule.TimeSpan.Hours * hourlyRate;
        }

        private double GetWeekendHourlyRate(WorkingTimeGroups timeGroup)
        {
            switch(timeGroup)
            {
                case WorkingTimeGroups.ReallyEarly:
                    return 30;
                case WorkingTimeGroups.RegularSchedule:
                    return 20;
                case WorkingTimeGroups.ReallyLate:
                    return 25;
                default: throw new ApplicationException("We are getting an invalid timeGroup for the schedule.");
            }
        }

        private double GetWeekdayHourlyRat(WorkingTimeGroups timeGroup)
        {
            switch (timeGroup)
            {
                case WorkingTimeGroups.ReallyEarly:
                    return 25;
                case WorkingTimeGroups.RegularSchedule:
                    return 15;
                case WorkingTimeGroups.ReallyLate:
                    return 20;
                default: throw new ApplicationException("We are getting an invalid timeGroup for the schedule.");
            }
        }
    }
}
