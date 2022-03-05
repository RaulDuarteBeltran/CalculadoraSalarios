using System;
using System.IO;
using Xunit;
using Common.Interfaces;
using Common.Utility;
using Common.Exceptions;
using Common.AbstractClasses;

namespace UnitTestingCalculadoraSalarios.StreamConverters
{
    public class MultiLineStreamConverterShould
    {
        
        [Fact]
        public void ReturnMultiLineString()
        {
            //Arrange
            IFileReader reader = new FileReader();
            var filename = "Test.txt";
            StreamReader streamReader = reader.GetStreamReader(filename);
            string expectedString =
                "RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00-21:00" +
                "\nASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00";

            StreamConverter streamConverter = new MultiLineStreamConverter();
            //Act
            string result = streamConverter.Convert(streamReader);


            //Assert
            Assert.Equal(expectedString, result);
        }
        
    }
}
