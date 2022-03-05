using System;
using System.IO;
using Common.Interfaces;

namespace Common.Utility
{
    public class FileReader : IFileReader
    {
        
        public StreamReader GetStreamReader(string fileName)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = File.OpenText(fileName);
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("You dont have permissions to open this file");
                
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("We couldn't find the directory that you specified");
                
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("We couldn't find the file that you specified");
                
            }
            catch(ApplicationException ex)
            {
                Console.WriteLine($"You got an exception of type {ex.GetType()} whit the message {ex.Message}");
                
            }

            return streamReader;

        }
    }
}
