using System;
using Common.Interfaces;
using Common.Enums;

namespace Common.Entities
{
    public class SimpleWorkedSchedule : IWorkedSchedule
    {
        public SimpleWorkedSchedule(WorkingDays workingDay,
            WorkingTimeGroups workingTG, TimeSpan timeSpan)
        {
            WorkingDay = workingDay;
            WorkingTimeGroup = workingTG;
            TimeSpan = timeSpan;
        }

        public WorkingDays WorkingDay {get; set;}

        public WorkingTimeGroups WorkingTimeGroup { get; set; }

        public TimeSpan TimeSpan { get; set; }

    }
}
