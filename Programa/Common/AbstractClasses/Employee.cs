using System;
using System.Collections.Generic;
using Common.Interfaces;

namespace Common.AbstractClasses
{
    public abstract class Employee
    {
        protected string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract IList<IWorkedSchedule> WorkedSchedule { get; }


        public Employee(string name)
        {
            Name = name;
        }

        public abstract void AddWorkedSchedule(IWorkedSchedule schedule);


    }
}
