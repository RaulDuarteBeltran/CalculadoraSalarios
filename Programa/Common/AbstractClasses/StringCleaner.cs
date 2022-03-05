using System;
namespace Common.AbstractClasses
{
    public abstract class StringCleaner
    {
        public StringCleaner()
        {
        }

        public abstract string CleanString(string stringToClean);
    }
}
