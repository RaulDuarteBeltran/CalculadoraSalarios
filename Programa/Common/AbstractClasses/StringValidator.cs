using System;
namespace Common.AbstractClasses
{
    public abstract class StringValidator
    {
        public StringValidator()
        {

        }

        public abstract void Validate(string stringToValidate);
    }
}
