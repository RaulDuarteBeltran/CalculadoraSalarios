using System;
using System.IO;
using Xunit;
using Common.Interfaces;
using Common.Utility;
using Common.Exceptions;

namespace UnitTestingCalculadoraSalarios.FileTests
{
    public class FileReaderShould
    {
        [Fact]
        public void ReturnFileReader()
        {
            //Arrange
            IFileReader reader = new FileReader();
            var filename = "Test.txt";

            //Act
            StreamReader streamReader = reader.GetStreamReader(filename);

            //Assert
            Assert.NotNull(streamReader);
        }
    }
}
