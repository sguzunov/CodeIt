using Newtonsoft.Json;

namespace CodeIt.CodeExecution.Models
{
    public class SubmissionIdentifier
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
