using System;
using System.Collections.Generic;
using Common.AbstractClasses;

namespace Common.AbstractClasses
{
    public abstract class StringParser
    {
        public StringParser()
        {
        }

        public abstract IList<Employee> Parse(string stringToParse);
    }
}
