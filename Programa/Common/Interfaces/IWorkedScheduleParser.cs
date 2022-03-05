using System;
using Common.Enums;
using Common.Interfaces;

namespace Common.Interfaces
{
    public interface IWorkedScheduleParser
    {
        public IWorkedSchedule Parse(string stringToParse);
    }
}
