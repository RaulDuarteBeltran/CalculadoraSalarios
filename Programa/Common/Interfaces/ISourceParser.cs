using System;
using System.Collections.Generic;
using Common.AbstractClasses;
using Common.Interfaces;

namespace Common.Interfaces
{
    public interface ISourceParser
    {
        public IList<Employee> Parse(string fileName);
    }
}
