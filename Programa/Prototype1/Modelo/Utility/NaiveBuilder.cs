using System;
using Common.Interfaces;
using Common.AbstractClasses;
using Common.Utility;

namespace Programa.Prototype1.Modelo.Utility
{
    public class NaiveBuilder : IParserBuilder
    {
        private IFileValidator _fileValidator;
        private IFileReader _fileReader;
        private StreamConverter _streamConverter;
        private StringParser _stringParser;

        public NaiveBuilder()
        {
            _fileValidator = new FileValidator();
            _fileReader = new FileReader();
            _streamConverter = new MultiLineStreamConverter();
            _stringParser = new SimpleEmployeeStringParser();
        }

        public ISourceParser Build()
        {
            return new NaiveParser(
                _fileValidator,
                _fileReader,
                _streamConverter,
                _stringParser
                );
        }
    }
}
