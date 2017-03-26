namespace CodeIt.CodeExecution.Helpers.Contracts
{
    public interface IJsonUtils
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string json);
    }
}
