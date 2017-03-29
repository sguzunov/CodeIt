using CodeIt.Data.Models;
using Newtonsoft.Json;

namespace CodeIt.CodeExecution.Models
{
    public class SubmissionOptions
    {
        [JsonProperty("language")]
        public Language Language { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("sourceCode")]
        public string SourceCode { get; set; }
    }
}
