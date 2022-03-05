using System;
using System.IO;
using Common.Interfaces;

namespace Common.Interfaces
{
    public interface IFileReader
    {
        //With this method we will get the StreamReader from the
        //for the textfile that we are going to consume.
        public StreamReader GetStreamReader(string fileName);
    }
}
