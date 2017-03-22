using Bytes2you.Validation;

using CodeIt.Services.Logic.Contracts;

namespace CodeIt.Services.Logic
{
    public class FileUnits : IFileUnits
    {
        public string ExtractFileExtension(string fullName)
        {
            Guard.WhenArgument(fullName, nameof(fullName)).IsNullOrEmpty().Throw();

            int lastDotIndex = fullName.LastIndexOf('.');
            string fileName = fullName.Substring(lastDotIndex + 1);
            return fileName;
        }

        public string ExtractFileName(string fullName)
        {
            Guard.WhenArgument(fullName, nameof(fullName)).IsNullOrEmpty().Throw();

            int lastDotIndex = fullName.LastIndexOf('.');
            string fileExt = fullName.Substring(0, lastDotIndex);
            return fileExt;
        }
    }
}
