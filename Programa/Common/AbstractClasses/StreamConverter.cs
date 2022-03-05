using System;
using System.IO;

namespace Common.AbstractClasses
{
    public abstract class StreamConverter
    {
        public StreamConverter()
        {

        }

        public abstract string Convert(StreamReader reader);
    }
}
