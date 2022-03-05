using System;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    [Serializable]
    public class FileValidationException : ApplicationException
    {
        public string FileName { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;

        public FileValidationException() { }
        public FileValidationException(string fileName, string route, string message)
            : this(fileName, route, message, null) { }
        public FileValidationException(string fileName, string route, string message, Exception inner)
            :base(message, inner)
        {
            FileName = fileName;
            Route = route;
        }

        protected FileValidationException(string fileName, string route, SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            FileName = fileName;
            Route = route;
        }
    }
}