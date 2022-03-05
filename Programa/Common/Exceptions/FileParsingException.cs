using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class FileParsingException : ApplicationException
    {
        public FileParsingException() { }
        public FileParsingException(string fileName, int lineNumber,string message)
            : this(fileName, lineNumber, message, null) { }
        public FileParsingException(string fileName, int lineNumber,string message, System.Exception inner)
            : base(message, inner)
        {
            FileName = fileName;
            LineNumber = lineNumber;
        }
        protected FileParsingException(string fileName, int lineNumber, SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            FileName = fileName;
            LineNumber = lineNumber;
        }

        public string FileName { get; set; } = string.Empty;
        public int LineNumber { get; set; } = 0;
    }
}
