using System;
using System.Collections.Generic;
using Common.AbstractClasses;
using Common.Interfaces;

namespace Common.Entities
{
    public class SimpleEmployee : Employee
    {
        private IList<IWorkedSchedule> _workedSchedules;

        public SimpleEmployee(string name) : base(name)
        {
            _workedSchedules = new List<IWorkedSchedule>();
        }

        public override IList<IWorkedSchedule> WorkedSchedule
        {
            get
            {
                return new List<IWorkedSchedule>(_workedSchedules);
            }
        }

        public override void AddWorkedSchedule(IWorkedSchedule schedule)
        {
            _workedSchedules.Add(schedule);
        }
    }
}
