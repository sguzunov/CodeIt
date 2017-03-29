using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeIt.CodeExecution.Helpers.Contracts
{
    public interface IHttpRequester
    {
        Task<T> GetJsonAsync<T>(string url, IDictionary<string, string> headers = null);

        Task<T> PostJsonAsync<T>(string url, string jsonData, IDictionary<string, string> headers = null);
    }
}
