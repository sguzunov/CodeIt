using Newtonsoft.Json;

namespace CodeIt.CodeExecution.Models
{
    public class SubmissionOptions
    {
        [JsonProperty("language")]
        public int Language { get; set; }

        [JsonProperty("input")]
        public int Input { get; set; }

        [JsonProperty("sourceCode")]
        public string SourceCode { get; set; }
    }
}
