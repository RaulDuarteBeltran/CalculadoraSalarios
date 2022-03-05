using System;
using System.IO;
using Xunit;
using Common.Interfaces;
using Common.Utility;
using Common.Exceptions;

namespace UnitTestingCalculadoraSalarios.FileTests
{
    public class FileValidatorShould
    {
        [Fact]
        public void ValidateNotExistingFile()
        {
            //Arrange
            IFileValidator validator = new FileValidator();
            var fileName = "NotExistentFile.txt";
            //Act
            Action act = () => validator.Validate(fileName);

            //Assert
            FileValidationException exception = Assert.Throws<FileValidationException>(act);
            Assert.Equal("The file NotExistentFile.txt doesn't exist", exception.Message);
        }

        [Fact]
        public void ValidateEmptyFile()
        {
            //Arrange
            IFileValidator validator = new FileValidator();
            var fileName = "EmptyFile.txt";

            //Act
            Action act = () => validator.Validate(fileName);

            FileValidationException exception = Assert.Throws<FileValidationException>(act);
            Assert.Equal($"The file { fileName} is empty.", exception.Message);
        }

        [Fact]
        public void ValidateIncorrectFormatFile()
        {
            //Arrange
            IFileValidator validator = new FileValidator();
            var fileName = "IncorrectFormat.doc";

            //Act
            Action act = () => validator.Validate(fileName);

            FileValidationException exception = Assert.Throws<FileValidationException>(act);
            Assert.Equal($"The file { fileName} is not in the right format. .txt expected", exception.Message);
        }

        
    }
}
