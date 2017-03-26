using CodeIt.CodeExecution.Helpers.Contracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CodeIt.CodeExecution.Helpers
{
    public class HttpRequester : IHttpRequester
    {
        private readonly IJsonUtils jsonUtils;

        public HttpRequester(IJsonUtils jsonUtils)
        {
            this.jsonUtils = jsonUtils;
        }

        public async Task<T> GetJsonAsync<T>(string url, IDictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    // TODO: Add headers
                }

                var httpResponse = await client.GetAsync(url);
                var data = this.jsonUtils.Deserialize<T>(await httpResponse.Content.ReadAsStringAsync());
                return data;
            }
        }

        public async Task<T> PostJsonAsync<T>(string url, string jsonData, IDictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                if (headers != null)
                {
                    // TODO: Add headers
                }

                var content = new StringContent(jsonData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var httpResponse = await client.PostAsync(url, content);
                {
                    var httpContent = await httpResponse.Content.ReadAsStringAsync();
                    var obj = this.jsonUtils.Deserialize<T>(httpContent);
                    return obj;
                }
            }
        }
    }
}
