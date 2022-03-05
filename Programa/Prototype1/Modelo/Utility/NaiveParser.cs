using System;
using System.IO;
using System.Collections.Generic;
using Common.AbstractClasses;
using Common.Interfaces;

namespace Programa.Prototype1.Modelo.Utility
{
    public class NaiveParser : ISourceParser
    {
        private IFileValidator _fileValidator;
        private IFileReader _fileReader;
        private StreamConverter _streamConverter;
        private StringParser _stringParser;

        public NaiveParser(IFileValidator fileValidator, IFileReader fileReader,
            StreamConverter streamConverter, StringParser stringParser)
        {
            _fileValidator = fileValidator;
            _fileReader = fileReader;
            _streamConverter = streamConverter;
            _stringParser = stringParser;
        }

        public IList<Employee> Parse(string fileName)
        {
            _fileValidator.Validate(fileName);
            StreamReader fileReader = _fileReader.GetStreamReader(fileName);
            string ConvertedStream = _streamConverter.Convert(fileReader);
            IList<Employee> parsedEmployeeList = _stringParser.Parse(ConvertedStream);
            return parsedEmployeeList;
        }
    }
}
