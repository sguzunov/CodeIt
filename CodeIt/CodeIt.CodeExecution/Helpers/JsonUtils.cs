using CodeIt.CodeExecution.Helpers.Contracts;

using Newtonsoft.Json;

namespace CodeIt.CodeExecution.Helpers
{
    public class JsonUtils : IJsonUtils
    {
        public T Deserialize<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public string Serialize<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }
    }
}
