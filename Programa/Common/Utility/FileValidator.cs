using System;
using System.IO;
using Common.Interfaces;
using Common.Exceptions;

namespace Common.Utility
{
    public class FileValidator: IFileValidator
    {
        public FileValidator()
        {
        }

        public void Validate(string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            bool fileExists = File.Exists($"{fileName}");
            if (!fileExists)
            {
                throw new FileValidationException(fileName, path,
                    $"The file {fileName} doesn't exist");
            }
            if (!fileName.EndsWith(".txt"))
            {
                throw new FileValidationException(fileName, path,
                    $"The file {fileName} is not in the right format. .txt expected");
            }
            if (new FileInfo(fileName).Length == 0)
            {
                throw new FileValidationException(fileName, path,
                    $"The file {fileName} is empty.");
            }
        }
    }
}
