using System;
using System.IO;
using Common.AbstractClasses;

namespace Common.Utility
{
    public class MultiLineStreamConverter : StreamConverter
    {
        public MultiLineStreamConverter()
        {
        }

        public override string Convert(StreamReader reader)
        {
            string output = string.Empty;
            string input = null;
            while((input = reader.ReadLine()) != null)
            {
                output += (input + '\n');
            }
            int lastChar = output.LastIndexOf('\n');
            output = output.Remove(lastChar);
            return output;
        }
    }
}
