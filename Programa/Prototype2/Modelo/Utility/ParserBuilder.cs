using System;
using Common.Interfaces;
using Common.AbstractClasses;
using Common.Utility;
using Prototype2.Modelo.Utility;

namespace Programa.Modelo.Utility
{
    public class ParserBuilder : IParserBuilder
    {
        private IFileValidator _fileValidator;
        private IFileReader _fileReader;
        private StreamConverter _streamConverter;
        private StringCleaner _stringCleaner;
        private StringValidator _stringValidator;
        private StringParser _stringParser;
        

        public ParserBuilder()
        {
            _fileValidator = new FileValidator();
            _fileReader = new FileReader();
            _streamConverter = new MultiLineStreamConverter();
            _stringCleaner = new MultiLineStringCleaner();
            _stringValidator = new ValidationListStringValidator();
            _stringParser = new SimpleEmployeeStringParser();
        }

        public ISourceParser Build()
        {
            throw new NotImplementedException();
            /*
            return new SourceParser(
                _fileValidator,
                _fileReader,
                _streamConverter,
                _stringCleaner,
                _stringValidator,
                _stringParser
                );*/
        }
    }
}
