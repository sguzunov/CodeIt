using Newtonsoft.Json;

namespace CodeIt.CodeExecution.Models
{
    public class SubmissionExecutionResult
    {
        [JsonProperty("time")]
        public double TimeExecution { get; set; }

        [JsonProperty("memory")]
        public double Memory { get; set; }

        [JsonProperty("output")]
        public string Output { get; set; }

        [JsonProperty("stderr")]
        public string RuntimeException { get; set; }

        [JsonProperty("cmpinfo")]
        public string CompileError { get; set; }

        [JsonProperty("langName")]
        public string Language { get; set; }

        [JsonProperty("langVersion")]
        public string LanguageVersion { get; set; }
    }
}
