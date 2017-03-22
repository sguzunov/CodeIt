namespace CodeIt.Services.Logic.Contracts
{
    public interface IFileUnits
    {
        string ExtractFileName(string fullName);

        string ExtractFileExtension(string fullName);
    }
}
