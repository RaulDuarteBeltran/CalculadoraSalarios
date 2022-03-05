using System;
using System.IO;
using System.Collections.Generic;
using Common.Interfaces;
using Common.AbstractClasses;
using Common.Exceptions;

namespace Programa.Modelo.Utility
{
    public class SourceParser : ISourceParser
    {
        /*
        private IFileReader _fileReader;
        private IStreamCleaner _streamCleaner;
        private IFileValidator _fileValidator;
        private StringValidator _stringValidator;
        private StringParser _stringParser;

        public SourceParser(
            IFileValidator fileValidator,
            IFileReader fileReader,
            IStreamCleaner streamCleaner,
            StringValidator stringValidator,
            StringParser stringParser
            )
        {
            _fileReader = fileReader;
            _streamCleaner = streamCleaner;
            _fileValidator = fileValidator;
            _stringValidator = stringValidator;
            _stringParser = stringParser;
        }

        public IList<Employee> Parse(string fileName)
        {
            _fileValidator.Validate(fileName);
            StreamReader fileReader = _fileReader.GetStreamReader(fileName);
            string cleanedText = _streamCleaner.Clean(fileReader);
            _stringValidator.Validate(cleanedText);
            IList<Employee> parsedEmployees = _stringParser.Parse(cleanedText);
            return parsedEmployees;
        }
        */
        public IList<Employee> Parse(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
