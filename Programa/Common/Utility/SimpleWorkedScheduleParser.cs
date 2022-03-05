using System;
using Common.Interfaces;
using Common.Utility;
using Common.Enums;
using Common.Entities;


namespace Common.Utility
{
    public class SimpleWorkedScheduleParser : IWorkedScheduleParser
    {
        public SimpleWorkedScheduleParser()
        {
        }

        public IWorkedSchedule Parse(string stringToParse)
        {
            string dayString = stringToParse.Substring(0, 2);
            WorkingDays workingDay = GetWorkingDay(dayString);

            string firstTimeString = stringToParse.Substring(2, 5);
            DateTime firstTime = GetDateTime(firstTimeString);

            string secondTimeString = stringToParse.Substring(8, 5);
            DateTime secondTime = GetDateTime(secondTimeString);

            WorkingTimeGroups timeGroup = GetWorkingTimeGroup(firstTime, secondTime);

            TimeSpan workedTime = GetWorkedTime(firstTime, secondTime);

            IWorkedSchedule workedSchedule = new SimpleWorkedSchedule(workingDay, timeGroup, workedTime);
            return workedSchedule;
        }

        private WorkingDays GetWorkingDay(string dayString)
        {
            switch(dayString)
            {
                case "MO": return WorkingDays.MO;
                case "TU": return WorkingDays.TU;
                case "WE": return WorkingDays.WE;
                case "TH": return WorkingDays.TH;
                case "FR": return WorkingDays.FR;
                case "SA": return WorkingDays.SA;
                case "SU": return WorkingDays.SU;
                default:
                    throw new ApplicationException("The specified day doesn't exists");
            }
        }

        private DateTime GetDateTime(string timeString)
        {
            //We should add the secconds to make the parsing possible.
            string formatedTimeSTring = timeString += ":00";
            return DateTime.Parse(formatedTimeSTring);
        }

        private WorkingTimeGroups GetWorkingTimeGroup(DateTime time1, DateTime time2)
        {
            //if we are between 00:01 and 9:00
            if (time1.IsPastMidnight() && !time2.isPast9AM())
            {
                return WorkingTimeGroups.ReallyEarly;
            }
            //if we are between 09:01 and 18:00
            else if (time1.isPast9AM() && !time2.IsPast6PM())
            {
                return WorkingTimeGroups.RegularSchedule;
            }
            //if we are between 18:01 and 00:00
            else if (time1.IsPast6PM() && (time2.IsBeforeMidnight() || time2.IsMidnight()))
            {
                return WorkingTimeGroups.ReallyLate;
            }
            else throw new ApplicationException("The time period is not valid");
            
        }

        private TimeSpan GetWorkedTime(DateTime firstTime, DateTime secondTime)
        {
            int firstHours = firstTime.Hour;
            int secondHours;
            if (secondTime.IsMidnight()) secondHours = 24;
            else secondHours = secondTime.Hour;

            int hours = secondHours - firstHours;

            return TimeSpan.FromHours(hours);
        }
    }

    //This class is for some extension methods that help me to validate times.
    public static class MyDateTimeExtensions
    {
        public static bool IsPastMidnight(this DateTime time)
        {
            if (time.IsMidnight())
            {
                return false;
            }
            else return true;
        }

        public static bool IsBeforeMidnight(this DateTime time)
        {
            if (time.Hour < 23 || time.Minute < 59)
            {
                return true;
            }
            else return false;
        }

        public static bool IsMidnight(this DateTime time)
        {
            if (time.Hour == 0 && time.Minute == 0)
            {
                return true;
            }
            else return false;
        }

        public static bool isPast9AM(this DateTime time)
        {
            if (time.Hour > 9 || time.Minute > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool IsPast6PM(this DateTime time)
        {
            if (time.Hour > 18 || time.Minute > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
