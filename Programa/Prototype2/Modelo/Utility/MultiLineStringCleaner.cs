using System;
using Common.AbstractClasses;

namespace Prototype2.Modelo.Utility
{
    public class MultiLineStringCleaner : StringCleaner
    {
        public MultiLineStringCleaner()
        {
        }

        public override string CleanString(string stringToClean)
        {
            string outputString = string.Empty;
            outputString = stringToClean.Replace(" ", string.Empty);
            outputString = outputString.Replace("\t", string.Empty);
            return outputString;
        }
    }
}
