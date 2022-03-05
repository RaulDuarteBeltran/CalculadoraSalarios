using System;
using Common.Enums;
using Common.Interfaces;

namespace Common.Interfaces
{
    public interface IWorkedSchedule
    {
        public WorkingDays WorkingDay { get; }
        public WorkingTimeGroups WorkingTimeGroup { get; }
        public TimeSpan TimeSpan { get; }
    }
}
